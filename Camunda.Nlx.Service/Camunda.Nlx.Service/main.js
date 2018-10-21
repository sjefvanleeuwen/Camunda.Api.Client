const { decisionTable } = require('./node_modules/@hbtgmbh/dmn-eval-js');
 
// const xmlContent = '' // wherever it may come from

module.exports = function(callback) { 
    // In this trivial example, we don't need to receive any 
    // parameters - we just send back a string 
    
    var message = 'Hello from Node at ' + new Date().toString(); 
    callback(/* error */ null, message); 
  
  };


// decisionTable.parseDmnXml(xmlContent)
//     .then((decisions) => {
//         // DMN was successfully parsed
//         const context = {
//             // your input for decision execution goes in here
//         };

//         try {
//             const data = decisionTable.evaluateDecision('decide-approval', decisions, context);
//             // data is the output of the decision execution
//             // it is an array for hit policy COLLECT and RULE ORDER, and an object else
//             // it is undefined if no rule matched
            
//             // do something with the data
            
//         } catch (err) {
//             // failed to evaluate rule, maybe the context is missing some data?
//             console.log(err)
//         };
//     })
//     .catch(err => {
//          // failed to parse DMN XML: either invalid XML or valid XML but invalid DMN
//          console.log(err)
//     });