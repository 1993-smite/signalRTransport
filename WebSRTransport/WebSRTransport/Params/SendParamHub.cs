namespace WebSRTransport.Params
{
    /// <summary>
    /// param for send by hubs
    /// </summary>
    public class SendParamHub
    {
        /// <summary>
        /// group name
        /// </summary>
        public string group { get; set; }

        /// <summary>
        /// message
        /// </summary>
        public string message { get; set; }
    }
}
