using Dapr.Client;

const string storeName = "statestore";
const string key = "counter";

var daprClient = new DaprClientBuilder().Build();

var counter = await daprClient.GetStateAsync<int>(storeName, key);

while (true)
{
  Console.WriteLine($"Counter = {counter++}");

  var daprSideCarIsHealthy = await daprClient.CheckHealthAsync();

  if(daprSideCarIsHealthy)
    Console.WriteLine("Dapr side car is healthy. !!!");
  else
  {
    Console.WriteLine("Alas, Alas, Dapr side car is NOT healthy !!");
    Console.WriteLine("I am not sure why the the state store is running fine when side car is not healthy ");
    Console.WriteLine("Need to find out.");
  }
  await daprClient.SaveStateAsync(storeName, key, counter);
  await Task.Delay(1000);
}
