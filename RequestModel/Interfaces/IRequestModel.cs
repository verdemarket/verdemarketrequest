using RequestModel;

namespace RequestModel
{
    public interface IRequestModel : IModel
    {
        public string id { get; set; }
        public Client client { get; set; }
        public Delivery[] delivery { get; set; }
        public Itemsrequest[] itemsrequest { get; set; }
        public Itemsprocessed[] itemsprocessed { get; set; }
        public Service[] services { get; set; }
        public string[] others { get; set; }
        public Total total { get; set; }
        public Status[] status { get; set; }
    }

    public interface IClient : IModel
    {
        public string name { get; set; }
        public string id { get; set; }
    }

    public interface ITotal
    {
        public Price price { get; set; }
    }

    public interface IPrice
    {
        public float value { get; set; }
        public string currency { get; set; }
    }

    public interface IDelivery : IModel
    {
        public string id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string[] observation { get; set; }
    }

    public interface IItemsrequest : IModel
    {
        public string id { get; set; }
        public int sequenceitem { get; set; }
        public string itemname { get; set; }
        public int quantity { get; set; }
        public string[] observations { get; set; }
    }

    public interface IItemsprocessed : IModel
    {
        public string id { get; set; }
        public int sequenceitem { get; set; }
        public string itemname { get; set; }
        public int quantity { get; set; }
        public string[] observations { get; set; }
        public Price price { get; set; }
    }

    public interface IService : IModel
    {
        public string id { get; set; }
        public string name { get; set; }
        public string[] description { get; set; }
        public Price price { get; set; }
    }

    public interface IStatus
    {
        public string description { get; set; }
        public string statusid { get; set; }
        public int statussequence { get; set; }
    }

}
