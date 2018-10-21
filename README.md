# az-speedtest-api
Azure implementation of the speedtest api

## Tutorial notes

### Dotnet new

* New webapi with `dotnet new webapi -o SpeedTestApi`
* GET https://localhost:5001/api/values (remember to turn off SSL valiadaton in Postman)
* Add .gitignore

### Bare-bones speedtest controller

* Rename controller
* Add model
* POST https://localhost:5001/speedtest (remember to set content type application/json)

```json
{
	"user": "my-test-user",
	"device": 1,
	"timestamp": 1535388782594,
	"data": "my-test-data"
}
```

### Create new Event Hub on Azure

* New Resource group: tae-cloud101
* New Event Hubs: tae-speedtest-events, Pricing: Basic, resource group: tae-cloud101, location: west europe
* I Event Hubs -> New event hub: speedtest-events

### Koble speedtest-api til Event Hub

* `dotnet add package Microsoft.Azure.EventHubs`
* New /Service and SpeedTestEvents