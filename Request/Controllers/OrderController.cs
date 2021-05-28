using MessageHandler;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RequestModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Web.Http.Controllers;

namespace Request.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOptions<Config> _config;

        public OrderController(IOptions<Config> config)
        {
            this._config = config;
        }

        [HttpPost("quoteorder")]
        public async Task<ActionResult<ApplicationModelResults<RequestModel.IRequestModel>>> QuoteOrder([ModelBinder(typeof(JsonModelBinder))] RequestModel.IRequestModel request)
        {
            var applicationModelResult = new ApplicationModelResults<RequestModel.IRequestModel>();

            if (request == null)
            {
                applicationModelResult.Error = new Error<IRequestModel> { Message = "Request must be fulfilled", Request = request };
                applicationModelResult.Results = new List<ApplicationModel<RequestModel.IRequestModel>> { new ApplicationModel<IRequestModel> { Error = applicationModelResult.Error } };

                return Task.Run(() =>
                {
                    return new ActionResult<ApplicationModelResults<IRequestModel>>(applicationModelResult);
                }).Result;
            }

            if (request.client == null)
            {
                applicationModelResult.Error = new Error<IRequestModel> { Message = "Client must be fulfilled", Request = request };
                applicationModelResult.Results = new List<ApplicationModel<IRequestModel>> { new ApplicationModel<IRequestModel> { Error = applicationModelResult.Error } };

                return Task.Run(() =>
                {
                    return new ActionResult<ApplicationModelResults<IRequestModel>>(applicationModelResult);
                }).Result;
            }

            if (request?.itemsrequest == null)
            {
                applicationModelResult.Error = new Error<IRequestModel> { Message = "Itens request must be supplied", Request = request };
                applicationModelResult.Results = new List<ApplicationModel<IRequestModel>> { new ApplicationModel<IRequestModel> { Error = applicationModelResult.Error } };

                return Task.Run(() => { return new ActionResult<ApplicationModelResults<IRequestModel>>(applicationModelResult); }).Result;

            }
            if (request?.itemsrequest.Length == 1 && request?.itemsrequest[0] == null)
            {

                applicationModelResult.Error = new Error<IRequestModel> { Message = "At least one order must be fulfilled", Request = request };
                applicationModelResult.Results = new List<ApplicationModel<IRequestModel>> { new ApplicationModel<IRequestModel> { Error = applicationModelResult.Error } };

                return Task.Run(() => { return new ActionResult<ApplicationModelResults<IRequestModel>>(applicationModelResult); }).Result;

            }

            HttpContext.Response.Headers.Add("Xablau", "Mil Grau");
            var sbConn = this._config.Value.serviceBusConnectionStringSender;
            var queueName = this._config.Value.serviceBusQueueName;
            var msgHandler = new ServiceBusHandler();

            if (await msgHandler.SendToServiceBusQueue(queueName, sbConn, request))
                return await Task.Run(() => { return (ApplicationModelResults<IRequestModel>)request; });
            else
            {
                HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return await Task.Run(() => { return new ApplicationModelResults<IRequestModel>(); });
            }
        }
    }

    public class JsonModelBinder : IModelBinder
    {
        readonly JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            var content = actionContext.Request.Content;
            string json = content.ReadAsStringAsync().Result;
            var obj = JsonConvert.DeserializeObject(json, bindingContext.ModelType, settings);
            bindingContext.Model = obj;
            return true;
        }

        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentException(nameof(bindingContext));
            }

            string valueFromBody = string.Empty;
            using (var sr = new StreamReader(bindingContext.HttpContext.Request.Body))
            {
                valueFromBody = Task.Run(async () => { return await sr.ReadToEndAsync(); }).Result;
            }

            if (string.IsNullOrEmpty(valueFromBody))
            {
                return;/// Task.CompletedTask;
            }

            var settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Auto
            };
            var obj = JsonConvert.DeserializeObject<RequestModel.RequestModel>(valueFromBody); ///JsonConvert.DeserializeObject(valueFromBody, bindingContext.ModelType, settings);
            bindingContext.Model = obj;
            bindingContext.Result = ModelBindingResult.Success(obj);
            return; /// Task.CompletedTask;
        }
    }
}
