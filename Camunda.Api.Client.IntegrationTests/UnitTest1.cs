using System;
using System.Text;
using Camunda.Api.Client.UserTask;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace Camunda.Api.Client.IntegrationTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TaskIntegrationTest()
        {
            //var client = CamundaClient.Create("http://localhost:2017/sjef-van-leeuwen/bpm-service/");
            var client = CamundaClient.Create("http://localhost:8080/engine-rest");
            var processInfo = new Camunda.Api.Client.ProcessDefinition.ProcessDefinitionQuery();
            processInfo.Key="brp";
            var process = new Camunda.Api.Client.ProcessInstance.ProcessInstanceWithVariables();
            var r = client.ProcessDefinitions.Query(processInfo).List().Result[0];
            var start = new Camunda.Api.Client.ProcessDefinition.StartProcessInstance();
            start.Variables = new System.Collections.Generic.Dictionary<string, VariableValue>();
            start.Variables.Add("bsn",VariableValue.FromObject("123456"));
            start.BusinessKey="123456";
            var rt = client.ProcessDefinitions[r.Id].StartProcessInstance(start).Result;
            var query = new UserTask.TaskQuery();
            query.CreatedAfter = DateTime.MinValue.ToString("yyyy-MM-dd'T'HH:mm:ss.fffzz00");
            query.ProcessInstanceBusinessKey = "123456";
            Thread.Sleep(5000); // allow BRP to be fetched
            var tasks = client.UserTasks.Query(query).List().Result;
            foreach(var task in tasks){
                var complete = new Camunda.Api.Client.UserTask.CompleteTask();
                complete.Variables.Add("selectPass",VariableValue.FromObject("digital"));
                client.UserTasks[task.Id].Complete(complete).Wait();
            }
        }
    }
}
