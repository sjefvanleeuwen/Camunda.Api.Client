# BPMN / DMN as a NLX Common Ground Service
![](https://directory.nlx.io/static/media/logo.325e26d6.svg)

## Status

This project is highly experimental. It researches the possibility in combining the NLX transport network for data and business process management "(BPM) as a service" and "Rules as a Service" (DMN decision modeling language).

Currently, single table Decision models are supported, but the programming model should be able to easily extend to Decision Diagrams containing multiple decision tables that interact with each other.

Though, not included in the example, consider the following diagram (in dutch)

A decision might involve multiple steps (each step is a decision table within the diagram).

>>add picture<<

Compared to the fact that decision tables are static, the attached entities to the decision tables are brought in from various external resources. This decision table is modeled after the welfare system accoording to the Dutch Law making process. The first decision table is dependend on the external factors of a person's (marital) sitaution being it:

* Either the requester or its partner should receive a pension (in Dutch law this is 65 years or older)
* Either they are maried with or without children
* Either the income is above or below a certain maximimum

Ofcourse there are other factors that could be modeled (is someone being detained?), this is merely an example.

## Conceptual Idea

To model complex decisions, several open standard products provide a DMN modeler for modeling these decisions. DMN's are part of a world wide industrial standard maintained by the OMG group.

https://www.omg.org/spec/DMN/About-DMN/

These decisions could be stored, forked and versioned on Github or any personal GIT repositroy. Rules are XML based and therefore are easily versioned using delta's. Organizations can fork and reuse rules and make slight alterations to them they fit their local policies.

In this project, a DMN model is executed using a RESTfull API that is provided on the inter organizational network NLX. Organizations on the NLX transport ring can then executre rules that they together maintain.

## Forking

When we talk about forking this means a lot in terms of organizing. While technologists here talk about forking, another explanation from a business perspective would talk about derivatives, some value that could be marketed in different niches. (BIG) Data might be valuable, but without the decision making process there is no value as data needs to be interepreted.

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
