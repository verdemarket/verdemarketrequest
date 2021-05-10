using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Request
{
    public class RequestTest
    {
        private readonly Controllers.OrderController _sut;
        private readonly Mock<RequestModel.IRequestModel> _requestMock;
        
        public RequestTest()
        {
            _sut = new Controllers.OrderController();
            _requestMock = new Mock<RequestModel.IRequestModel>();
            
            _requestMock.SetupAllProperties();
            _requestMock.Setup(x => x.client).Returns(new RequestModel.Client());
            _requestMock.Setup(x => x.itemsrequest).Returns(new RequestModel.Itemsrequest[1]);

        }

        [Fact]
        public async Task Test_Check_Response_Valid_Request()
        {
            _requestMock.Object.client = null;
            
            var TaskResult = await _sut.QuoteOrder(_requestMock.Object);

            Assert.Equal("Client must be fulfilled", TaskResult.Value.Error.Message);
        }

        [Fact]
        public async Task When_Request_Parameter_Is_Null_Return_Null()
        {
            var returnSUT = await _sut.QuoteOrder(null);
            
            Assert.Equal("Request must be fulfilled", returnSUT.Value.Error.Message);
        }

        [Fact]
        public async Task When_Request_Client_Is_Null_Return_Message_Error()
        {
            _requestMock.Object.client = null;
            var returnSUT = await _sut.QuoteOrder(_requestMock.Object);
            Assert.True(returnSUT.Value.HasError);
            Assert.Equal("Client must be fulfilled", returnSUT.Value.Error.Message);
        }

        [Fact]
        public async Task When_OrderRequest_Is_Null_Should_Return_Error_Message()
        {
            _requestMock.Object.itemsrequest = null;

            var returnSUT = await _sut.QuoteOrder(_requestMock.Object);
            Assert.True(returnSUT.Value.HasError);
            Assert.Equal("Itens request must be supplied", returnSUT.Value.Error.Message);
        }

        [Fact]
        public async Task When_OrderRequest_Has_No_Item_Should_Return_Error_Message()
        {
            //_requestMock.Object.itemsrequest = null;

            var returnSUT = await _sut.QuoteOrder(_requestMock.Object);
            Assert.True(returnSUT.Value.HasError);
            Assert.Equal("At least one order must be fulfilled", returnSUT.Value.Error.Message);
        }
    }
}
