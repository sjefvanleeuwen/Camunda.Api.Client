# Camunda on NLX

## Status

This project is highly experimental. It researches the possibility in combining NLX transport network in BPM and Rules (DMN decision modelling language).

## Conceptual Idea

Camunda provides a dmn modeler, for modeling decisions. These decisions can then be stored forked and versioned on Github.

The dmn model is executed using a RESTfull API that is provided on the inter organizational network NLX.

Organizaitons on the NLX transport ring can then executre rules that they together maintain.

## Example

In the example below, we use a DMN decision table located on Github master branch and executes it via NLX.

### Temperature Decision Table

The following decision table is modeled

![temperature](./doc/temperature.dmn.png)

### Input

```json
{
  "uri": "https://raw.githubusercontent.com/sjefvanleeuwen/camunda-process-examples/master/basic-dmn/basic-dmn/Resources/temperatureCategorizationDecision.dmn",
  "decisionDefinition" : "temperatureCategorizationDecision"
  "Input": "{\"temperature\":50}"
}
```

### Output

```json
{
    "category": "extreme hot"
}

```

### API Description on Swaggerhub

Follow [this]("") link