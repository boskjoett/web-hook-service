using System;
using Xunit;
using Newtonsoft.Json.Linq;

namespace WebhookService.Test
{
    public class JsonParserTests
    {
        [Fact]
        public void Test1()
        {
            string json =
                "{" +
                  "\"subscriptionId\": \"10d78023-0c9a-4b1c-92c4-4e4981f54211\"," +
                  "\"notificationId\": 7," +
                  "\"id\": \"4a5d99d6-1c75-4e53-91b9-ee80057d4ce3\"," +
                  "\"eventType\": \"build.complete\"," +
                  "\"publisherId\": \"tfs\"," +
                  "\"message\": null," +
                  "\"detailedMessage\": null," +
                  "\"resource\": null," +
                  "\"resourceVersion\": null," +
                  "\"resourceContainers\": {" +
                        "\"collection\": {" +
                            "\"id\": \"c12d0eb8 -e382-443b-9f9c-c52cba5014c2\"" +
                        "}," +
                        "\"account\": {" +
                            "\"id\": \"f844ec47 -a9db-4511-8281-8b63f4eaf94e\"" +
                        "}," +
                        "\"project\": {" +
                            "\"id\": \"be9b3917 -87e6-42a4-a549-2bc06a7a878f\"" +
                        "}" +
                  "}," +
                  "\"createdDate\": \"2018-12-16T11:18:38.024919Z\"" +
                "}";


            JObject jObject = JObject.Parse(json);

            string Id = (string)jObject["id"];
            string EventType = (string)jObject["eventType"];

            JToken n = jObject["resource"];
            if (n.HasValues)
            {
                string ResourceUrl = (string)jObject["resource"]["url"];
            }

            if (jObject["resourceContainers"] != null)
            {
                string ProjectId = (string)jObject["resourceContainers"]["project"]["id"];
            }

            DateTime CreatedTime = (DateTime)jObject["createdDate"];
        }
    }
}
