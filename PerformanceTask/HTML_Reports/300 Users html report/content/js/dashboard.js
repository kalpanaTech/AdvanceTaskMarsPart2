/*
   Licensed to the Apache Software Foundation (ASF) under one or more
   contributor license agreements.  See the NOTICE file distributed with
   this work for additional information regarding copyright ownership.
   The ASF licenses this file to You under the Apache License, Version 2.0
   (the "License"); you may not use this file except in compliance with
   the License.  You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/
var showControllersOnly = false;
var seriesFilter = "";
var filtersOnlySampleSeries = true;

/*
 * Add header in statistics table to group metrics by category
 * format
 *
 */
function summaryTableHeader(header) {
    var newRow = header.insertRow(-1);
    newRow.className = "tablesorter-no-sort";
    var cell = document.createElement('th');
    cell.setAttribute("data-sorter", false);
    cell.colSpan = 1;
    cell.innerHTML = "Requests";
    newRow.appendChild(cell);

    cell = document.createElement('th');
    cell.setAttribute("data-sorter", false);
    cell.colSpan = 3;
    cell.innerHTML = "Executions";
    newRow.appendChild(cell);

    cell = document.createElement('th');
    cell.setAttribute("data-sorter", false);
    cell.colSpan = 7;
    cell.innerHTML = "Response Times (ms)";
    newRow.appendChild(cell);

    cell = document.createElement('th');
    cell.setAttribute("data-sorter", false);
    cell.colSpan = 1;
    cell.innerHTML = "Throughput";
    newRow.appendChild(cell);

    cell = document.createElement('th');
    cell.setAttribute("data-sorter", false);
    cell.colSpan = 2;
    cell.innerHTML = "Network (KB/sec)";
    newRow.appendChild(cell);
}

/*
 * Populates the table identified by id parameter with the specified data and
 * format
 *
 */
function createTable(table, info, formatter, defaultSorts, seriesIndex, headerCreator) {
    var tableRef = table[0];

    // Create header and populate it with data.titles array
    var header = tableRef.createTHead();

    // Call callback is available
    if(headerCreator) {
        headerCreator(header);
    }

    var newRow = header.insertRow(-1);
    for (var index = 0; index < info.titles.length; index++) {
        var cell = document.createElement('th');
        cell.innerHTML = info.titles[index];
        newRow.appendChild(cell);
    }

    var tBody;

    // Create overall body if defined
    if(info.overall){
        tBody = document.createElement('tbody');
        tBody.className = "tablesorter-no-sort";
        tableRef.appendChild(tBody);
        var newRow = tBody.insertRow(-1);
        var data = info.overall.data;
        for(var index=0;index < data.length; index++){
            var cell = newRow.insertCell(-1);
            cell.innerHTML = formatter ? formatter(index, data[index]): data[index];
        }
    }

    // Create regular body
    tBody = document.createElement('tbody');
    tableRef.appendChild(tBody);

    var regexp;
    if(seriesFilter) {
        regexp = new RegExp(seriesFilter, 'i');
    }
    // Populate body with data.items array
    for(var index=0; index < info.items.length; index++){
        var item = info.items[index];
        if((!regexp || filtersOnlySampleSeries && !info.supportsControllersDiscrimination || regexp.test(item.data[seriesIndex]))
                &&
                (!showControllersOnly || !info.supportsControllersDiscrimination || item.isController)){
            if(item.data.length > 0) {
                var newRow = tBody.insertRow(-1);
                for(var col=0; col < item.data.length; col++){
                    var cell = newRow.insertCell(-1);
                    cell.innerHTML = formatter ? formatter(col, item.data[col]) : item.data[col];
                }
            }
        }
    }

    // Add support of columns sort
    table.tablesorter({sortList : defaultSorts});
}

$(document).ready(function() {

    // Customize table sorter default options
    $.extend( $.tablesorter.defaults, {
        theme: 'blue',
        cssInfoBlock: "tablesorter-no-sort",
        widthFixed: true,
        widgets: ['zebra']
    });

    var data = {"OkPercent": 99.8840579710145, "KoPercent": 0.11594202898550725};
    var dataset = [
        {
            "label" : "FAIL",
            "data" : data.KoPercent,
            "color" : "#FF6347"
        },
        {
            "label" : "PASS",
            "data" : data.OkPercent,
            "color" : "#9ACD32"
        }];
    $.plot($("#flot-requests-summary"), dataset, {
        series : {
            pie : {
                show : true,
                radius : 1,
                label : {
                    show : true,
                    radius : 3 / 4,
                    formatter : function(label, series) {
                        return '<div style="font-size:8pt;text-align:center;padding:2px;color:white;">'
                            + label
                            + '<br/>'
                            + Math.round10(series.percent, -2)
                            + '%</div>';
                    },
                    background : {
                        opacity : 0.5,
                        color : '#000'
                    }
                }
            }
        },
        legend : {
            show : true
        }
    });

    // Creates APDEX table
    createTable($("#apdexTable"), {"supportsControllersDiscrimination": true, "overall": {"data": [0.998840579710145, 500, 1500, "Total"], "isController": false}, "titles": ["Apdex", "T (Toleration threshold)", "F (Frustration threshold)", "Label"], "items": [{"data": [1.0, 500, 1500, "SignOut"], "isController": false}, {"data": [1.0, 500, 1500, "Update Skills"], "isController": false}, {"data": [0.9966666666666667, 500, 1500, "Add Languages"], "isController": false}, {"data": [1.0, 500, 1500, "Add Education"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Education"], "isController": false}, {"data": [1.0, 500, 1500, "Add Certification"], "isController": false}, {"data": [1.0, 500, 1500, "Add Description"], "isController": false}, {"data": [1.0, 500, 1500, "View Manage Listings"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Skills"], "isController": false}, {"data": [1.0, 500, 1500, "Share Skills"], "isController": false}, {"data": [1.0, 500, 1500, "Search Skills"], "isController": false}, {"data": [1.0, 500, 1500, "Enable Manage Listings"], "isController": false}, {"data": [0.9866666666666667, 500, 1500, "Update Languages"], "isController": false}, {"data": [0.9966666666666667, 500, 1500, "Delete Languages"], "isController": false}, {"data": [0.9966666666666667, 500, 1500, "Update Education"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Share Skills"], "isController": false}, {"data": [1.0, 500, 1500, "Disable Manage Listings"], "isController": false}, {"data": [1.0, 500, 1500, "Add Skills"], "isController": false}, {"data": [0.9966666666666667, 500, 1500, "Update Certification"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Manage Listings"], "isController": false}, {"data": [1.0, 500, 1500, "Add Manage Listings"], "isController": false}, {"data": [1.0, 500, 1500, "SignIn"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Certification"], "isController": false}]}, function(index, item){
        switch(index){
            case 0:
                item = item.toFixed(3);
                break;
            case 1:
            case 2:
                item = formatDuration(item);
                break;
        }
        return item;
    }, [[0, 0]], 3);

    // Create statistics table
    createTable($("#statisticsTable"), {"supportsControllersDiscrimination": true, "overall": {"data": ["Total", 6900, 8, 0.11594202898550725, 6.766231884057988, 2, 89, 5.0, 7.0, 9.0, 55.0, 229.60202315985626, 49.09738484543458, 160.17672232713298], "isController": false}, "titles": ["Label", "#Samples", "FAIL", "Error %", "Average", "Min", "Max", "Median", "90th pct", "95th pct", "99th pct", "Transactions/s", "Received", "Sent"], "items": [{"data": ["SignOut", 300, 0, 0.0, 2.8400000000000003, 2, 5, 3.0, 3.0, 4.0, 4.0, 10.09319382296538, 2.0466316068364567, 5.490145468155974], "isController": false}, {"data": ["Update Skills", 300, 0, 0.0, 6.056666666666663, 4, 13, 6.0, 7.0, 8.0, 10.980000000000018, 10.046549010414923, 2.030894184722548, 6.445881542815043], "isController": false}, {"data": ["Add Languages", 300, 1, 0.3333333333333333, 3.326666666666666, 2, 25, 3.0, 4.0, 4.0, 10.0, 10.050587959395624, 2.0328557384669503, 5.928276491674763], "isController": false}, {"data": ["Add Education", 300, 0, 0.0, 3.1300000000000017, 2, 6, 3.0, 4.0, 4.0, 5.990000000000009, 10.05361930294906, 2.032323433310992, 6.872591320375335], "isController": false}, {"data": ["Delete Education", 300, 0, 0.0, 3.529999999999997, 2, 7, 3.0, 4.0, 5.0, 5.0, 10.05631536604988, 2.1408952634754623, 5.823627941472244], "isController": false}, {"data": ["Add Certification", 300, 0, 0.0, 3.230000000000001, 2, 8, 3.0, 4.0, 4.0, 5.990000000000009, 10.056989607777405, 2.0330047351659406, 6.550793035534697], "isController": false}, {"data": ["Add Description", 300, 0, 0.0, 4.640000000000002, 2, 16, 5.0, 6.0, 6.949999999999989, 8.990000000000009, 10.059687479042317, 2.152353966870096, 6.2283611930789355], "isController": false}, {"data": ["View Manage Listings", 300, 0, 0.0, 2.98, 2, 4, 3.0, 3.0, 4.0, 4.0, 10.085728693898133, 2.04511787695411, 5.889907967725668], "isController": false}, {"data": ["Delete Skills", 300, 0, 0.0, 3.686666666666666, 2, 16, 4.0, 4.0, 5.0, 6.0, 10.049577917727456, 1.9039239414444593, 6.447824894479432], "isController": false}, {"data": ["Share Skills", 300, 0, 0.0, 5.913333333333328, 4, 54, 6.0, 6.0, 7.0, 12.960000000000036, 10.059687479042317, 2.200556636040507, 17.653572656092816], "isController": false}, {"data": ["Search Skills", 300, 0, 0.0, 2.963333333333334, 2, 13, 3.0, 3.0, 4.0, 4.990000000000009, 10.092854259184497, 2.0465627523213565, 6.00248851937828], "isController": false}, {"data": ["Enable Manage Listings", 300, 0, 0.0, 5.533333333333335, 4, 26, 5.0, 6.0, 7.0, 8.990000000000009, 10.085389632219458, 1.8713125294157198, 5.712427721374302], "isController": false}, {"data": ["Update Languages", 300, 4, 1.3333333333333333, 5.870000000000003, 4, 14, 6.0, 7.0, 7.949999999999989, 10.980000000000018, 10.05126143330988, 2.1131861032934633, 6.242219433695179], "isController": false}, {"data": ["Delete Languages", 300, 1, 0.3333333333333333, 3.453333333333333, 2, 8, 3.0, 4.0, 4.0, 6.0, 10.05294551303532, 1.9311014572582268, 5.811302809379399], "isController": false}, {"data": ["Update Education", 300, 1, 0.3333333333333333, 5.843333333333337, 3, 25, 6.0, 7.0, 7.949999999999989, 10.980000000000018, 10.053956231777205, 2.1405566645162373, 7.226281041589866], "isController": false}, {"data": ["Delete Share Skills", 300, 0, 0.0, 6.843333333333331, 5, 71, 6.0, 7.0, 8.0, 11.0, 10.06204930404159, 2.004548884789535, 5.7581649337581755], "isController": false}, {"data": ["Disable Manage Listings", 300, 0, 0.0, 5.460000000000001, 4, 20, 5.0, 6.0, 7.0, 9.990000000000009, 10.085728693898133, 1.8615260968229954, 5.71261976802824], "isController": false}, {"data": ["Add Skills", 300, 0, 0.0, 4.503333333333333, 3, 25, 4.0, 5.0, 6.0, 7.0, 10.040496669901938, 2.02967071354463, 6.26550524615951], "isController": false}, {"data": ["Update Certification", 300, 1, 0.3333333333333333, 6.366666666666668, 4, 12, 6.0, 8.0, 8.0, 9.0, 10.056989607777405, 1.7202952145491117, 6.973108028830037], "isController": false}, {"data": ["Delete Manage Listings", 300, 0, 0.0, 6.739999999999997, 5, 18, 7.0, 8.0, 8.0, 10.0, 10.090477952305674, 1.990504439810299, 5.7744336719249265], "isController": false}, {"data": ["Add Manage Listings", 300, 0, 0.0, 4.490000000000001, 3, 9, 4.0, 5.0, 6.0, 6.990000000000009, 10.084372583952401, 2.2059565027395878, 17.67719608222125], "isController": false}, {"data": ["SignIn", 300, 0, 0.0, 54.42999999999997, 50, 89, 53.0, 57.0, 61.0, 72.98000000000002, 10.015691249624412, 4.812226655092979, 3.136163322538644], "isController": false}, {"data": ["Delete Certification", 300, 0, 0.0, 3.793333333333334, 3, 7, 4.0, 4.0, 5.0, 6.0, 10.059687479042317, 2.131691002028704, 5.864876391590101], "isController": false}]}, function(index, item){
        switch(index){
            // Errors pct
            case 3:
                item = item.toFixed(2) + '%';
                break;
            // Mean
            case 4:
            // Mean
            case 7:
            // Median
            case 8:
            // Percentile 1
            case 9:
            // Percentile 2
            case 10:
            // Percentile 3
            case 11:
            // Throughput
            case 12:
            // Kbytes/s
            case 13:
            // Sent Kbytes/s
                item = item.toFixed(2);
                break;
        }
        return item;
    }, [[0, 0]], 0, summaryTableHeader);

    // Create error table
    createTable($("#errorsTable"), {"supportsControllersDiscrimination": false, "titles": ["Type of error", "Number of errors", "% in errors", "% in all samples"], "items": [{"data": ["Test failed: text expected to contain /true/", 7, 87.5, 0.10144927536231885], "isController": false}, {"data": ["500/Internal Server Error", 1, 12.5, 0.014492753623188406], "isController": false}]}, function(index, item){
        switch(index){
            case 2:
            case 3:
                item = item.toFixed(2) + '%';
                break;
        }
        return item;
    }, [[1, 1]]);

        // Create top5 errors by sampler
    createTable($("#top5ErrorsBySamplerTable"), {"supportsControllersDiscrimination": false, "overall": {"data": ["Total", 6900, 8, "Test failed: text expected to contain /true/", 7, "500/Internal Server Error", 1, "", "", "", "", "", ""], "isController": false}, "titles": ["Sample", "#Samples", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors"], "items": [{"data": [], "isController": false}, {"data": [], "isController": false}, {"data": ["Add Languages", 300, 1, "Test failed: text expected to contain /true/", 1, "", "", "", "", "", "", "", ""], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": ["Update Languages", 300, 4, "Test failed: text expected to contain /true/", 4, "", "", "", "", "", "", "", ""], "isController": false}, {"data": ["Delete Languages", 300, 1, "500/Internal Server Error", 1, "", "", "", "", "", "", "", ""], "isController": false}, {"data": ["Update Education", 300, 1, "Test failed: text expected to contain /true/", 1, "", "", "", "", "", "", "", ""], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": ["Update Certification", 300, 1, "Test failed: text expected to contain /true/", 1, "", "", "", "", "", "", "", ""], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}]}, function(index, item){
        return item;
    }, [[0, 0]], 0);

});
