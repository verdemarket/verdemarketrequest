using System.Collections.Generic;

namespace RequestModel
{
    public class ApplicationModel<T> : IModel
    {
        public string id { get; set; }

        public Error<T> Error { get; set; }
        public T Result { get; set; }
        public bool HasError
        {
            get { return Error != null; }
        }
    }

    public class ApplicationModelResults<T>
    {
        public ApplicationModelResults() => Results = new List<ApplicationModel<T>>();

        public Error<T> Error { get; set; }
        public List<ApplicationModel<T>> Results { get; set; }
        public bool HasError
        {
            get { return Error != null; }
        }
    }
}
