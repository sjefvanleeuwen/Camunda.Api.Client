# BPMN / DMN as a NLX Common Ground Service
![](https://directory.nlx.io/static/media/logo.325e26d6.svg)

## Status

This project is highly experimental. It researches the possibility in combining NLX transport network for data and business process management "(BPM) as a service" and "Rules as a Service" (DMN decision modeling language).

Currently single table Decision models are supported.

## Conceptual Idea

Several open standard products provide a DMN modeler for modeling decisions. DMN's are part of a world wide industrial standard maintained by the OMG group.

https://www.omg.org/spec/DMN/About-DMN/

These decisions could be stored, forked and versioned on Github or any personal GIT repositroy. Rules are XML based and therefore are easily versioned using delta's. Organizations can fork and reuse rules and make slight alterations to them they fit their local policies.

In this project, a DMN model is executed using a RESTfull API that is provided on the inter organizational network NLX. Organizations on the NLX transport ring can then executre rules that they together maintain.

## DMN As An NLX Service Example

In the example below, we use a DMN decision table located on Github master branch and executes it via NLX.

### Temperature Decision Table

The following decision table is modeled

![temperature](./doc/temperature.dmn.png)

### Input

```json
{
  "uri" : "https://raw.githubusercontent.com/sjefvanleeuwen/Camunda.Api.Client/master/Camunda.Nlx.Service/doc/temperatureCategorizationDecision.dmn",
  "decisionDefinition" : "temperatureCategorizationDecision",
  "input" : "{\"temperature\":50}"
}
```

### Output

```json
{
    "category": "extreme hot"
}

```

### Service location

http://{your-outway-address}:{your-outway-port}/sjef-van-leeuwen/bpm-service

![nlx-directory](./doc/nlx-directory.png)

For more information on setting up an outway on NLX can be found at:
https://docs.nlx.io/

### API Description on Swaggerhub

Follow [this](https://petstore.swagger.io/?url=https://raw.githubusercontent.com/sjefvanleeuwen/Camunda.Api.Client/master/Camunda.Nlx.Service/doc/swagger.json) link
