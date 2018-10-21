const { decisionTable } = require('@hbtgmbh/dmn-eval-js');
module.exports = function(callback, dmnModel, context, decisionDefinition) { 
  decisionTable.parseDmnXml(dmnModel).then((decisions) => {
        var ret;
        try {
            const data = decisionTable.evaluateDecision(
                decisionDefinition, decisions, JSON.parse(context));
            ret=JSON.stringify(data);
            
        } catch (err) {
            console.log(err)
        };
    callback(null,ret);
  }).catch((exception) => {
    callback(null,exception.message);    
  });
}
