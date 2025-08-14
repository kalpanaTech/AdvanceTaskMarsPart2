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

    var data = {"OkPercent": 98.26086956521739, "KoPercent": 1.7391304347826086};
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
    createTable($("#apdexTable"), {"supportsControllersDiscrimination": true, "overall": {"data": [0.9826086956521739, 500, 1500, "Total"], "isController": false}, "titles": ["Apdex", "T (Toleration threshold)", "F (Frustration threshold)", "Label"], "items": [{"data": [1.0, 500, 1500, "SignOut"], "isController": false}, {"data": [1.0, 500, 1500, "Update Skills"], "isController": false}, {"data": [0.9, 500, 1500, "Add Languages"], "isController": false}, {"data": [1.0, 500, 1500, "Add Education"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Education"], "isController": false}, {"data": [1.0, 500, 1500, "Add Certification"], "isController": false}, {"data": [1.0, 500, 1500, "Add Description"], "isController": false}, {"data": [1.0, 500, 1500, "View Manage Listings"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Skills"], "isController": false}, {"data": [1.0, 500, 1500, "Share Skills"], "isController": false}, {"data": [1.0, 500, 1500, "Search Skills"], "isController": false}, {"data": [1.0, 500, 1500, "Enable Manage Listings"], "isController": false}, {"data": [0.8, 500, 1500, "Update Languages"], "isController": false}, {"data": [0.9, 500, 1500, "Delete Languages"], "isController": false}, {"data": [1.0, 500, 1500, "Update Education"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Share Skills"], "isController": false}, {"data": [1.0, 500, 1500, "Disable Manage Listings"], "isController": false}, {"data": [1.0, 500, 1500, "Add Skills"], "isController": false}, {"data": [1.0, 500, 1500, "Update Certification"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Manage Listings"], "isController": false}, {"data": [1.0, 500, 1500, "Add Manage Listings"], "isController": false}, {"data": [1.0, 500, 1500, "SignIn"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Certification"], "isController": false}]}, function(index, item){
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
    createTable($("#statisticsTable"), {"supportsControllersDiscrimination": true, "overall": {"data": ["Total", 230, 4, 1.7391304347826086, 7.752173913043477, 3, 87, 5.0, 8.0, 17.899999999999977, 56.06999999999999, 50.460728389644586, 10.777539148200965, 35.192458657854324], "isController": false}, "titles": ["Label", "#Samples", "FAIL", "Error %", "Average", "Min", "Max", "Median", "90th pct", "95th pct", "99th pct", "Transactions/s", "Received", "Sent"], "items": [{"data": ["SignOut", 10, 0, 0.0, 3.5, 3, 4, 3.5, 4.0, 4.0, 4.0, 2.328830926874709, 0.46872270901257573, 1.2667566662785283], "isController": false}, {"data": ["Update Skills", 10, 0, 0.0, 8.3, 6, 15, 7.0, 14.500000000000002, 15.0, 15.0, 2.3180343069077423, 0.46858701321279556, 1.487254433240612], "isController": false}, {"data": ["Add Languages", 10, 1, 10.0, 4.499999999999999, 3, 7, 4.0, 6.800000000000001, 7.0, 7.0, 2.321262766945218, 0.4771736449628598, 1.3691823351903436], "isController": false}, {"data": ["Add Education", 10, 0, 0.0, 4.7, 4, 9, 4.0, 8.600000000000001, 9.0, 9.0, 2.321262766945218, 0.46923964136490254, 1.5868007195914577], "isController": false}, {"data": ["Delete Education", 10, 0, 0.0, 4.6000000000000005, 4, 6, 4.5, 5.9, 6.0, 6.0, 2.3207240659085633, 0.49406039684381525, 1.343934932699002], "isController": false}, {"data": ["Add Certification", 10, 0, 0.0, 4.3, 3, 8, 4.0, 7.700000000000001, 8.0, 8.0, 2.3207240659085633, 0.4691307437920631, 1.5116435077744255], "isController": false}, {"data": ["Add Description", 10, 0, 0.0, 5.9, 5, 7, 6.0, 6.9, 7.0, 7.0, 2.320185614849188, 0.4984773781902553, 1.4365211716937356], "isController": false}, {"data": ["View Manage Listings", 10, 0, 0.0, 3.5999999999999996, 3, 4, 4.0, 4.0, 4.0, 4.0, 2.328288707799767, 0.4686135768335274, 1.3596842258440047], "isController": false}, {"data": ["Delete Skills", 10, 0, 0.0, 4.5, 3, 7, 4.0, 6.800000000000001, 7.0, 7.0, 2.320185614849188, 0.4395664153132251, 1.4886347157772624], "isController": false}, {"data": ["Share Skills", 10, 0, 0.0, 7.5, 5, 17, 6.5, 16.1, 17.0, 17.0, 2.320185614849188, 0.5075406032482599, 4.071653857308585], "isController": false}, {"data": ["Search Skills", 10, 0, 0.0, 3.6999999999999997, 3, 4, 4.0, 4.0, 4.0, 4.0, 2.328288707799767, 0.4686135768335274, 1.3846951396973224], "isController": false}, {"data": ["Enable Manage Listings", 10, 0, 0.0, 5.7, 5, 7, 6.0, 6.9, 7.0, 7.0, 2.3266635644485807, 0.4317051535597953, 1.317836784550954], "isController": false}, {"data": ["Update Languages", 10, 2, 20.0, 6.8999999999999995, 5, 12, 6.0, 11.600000000000001, 12.0, 12.0, 2.320185614849188, 0.49439892691415316, 1.4372009135730859], "isController": false}, {"data": ["Delete Languages", 10, 1, 10.0, 4.499999999999999, 3, 6, 4.5, 5.9, 6.0, 6.0, 2.3207240659085633, 0.42675033360408443, 1.3378158360408448], "isController": false}, {"data": ["Update Education", 10, 0, 0.0, 7.3999999999999995, 6, 11, 7.0, 10.700000000000001, 11.0, 11.0, 2.319109461966605, 0.4937166628014842, 1.666859925788497], "isController": false}, {"data": ["Delete Share Skills", 10, 0, 0.0, 7.3999999999999995, 6, 9, 7.0, 8.9, 9.0, 9.0, 2.3255813953488373, 0.4632994186046512, 1.3308502906976745], "isController": false}, {"data": ["Disable Manage Listings", 10, 0, 0.0, 5.9, 5, 8, 6.0, 7.800000000000001, 8.0, 8.0, 2.3277467411545625, 0.42963294343575414, 1.3184503026070762], "isController": false}, {"data": ["Add Skills", 10, 0, 0.0, 7.300000000000001, 5, 19, 5.5, 18.000000000000004, 19.0, 19.0, 2.311604253351826, 0.46728718793342583, 1.4424952323162277], "isController": false}, {"data": ["Update Certification", 10, 0, 0.0, 6.5, 6, 7, 6.5, 7.0, 7.0, 7.0, 2.3196474135931338, 0.39642411853398285, 1.6083492809093018], "isController": false}, {"data": ["Delete Manage Listings", 10, 0, 0.0, 7.199999999999999, 6, 8, 7.0, 8.0, 8.0, 8.0, 2.3266635644485807, 0.4589707422056771, 1.3314695788738948], "isController": false}, {"data": ["Add Manage Listings", 10, 0, 0.0, 5.0, 4, 6, 5.0, 6.0, 6.0, 6.0, 2.3277467411545625, 0.5091945996275605, 4.08037636755121], "isController": false}, {"data": ["SignIn", 10, 0, 0.0, 55.0, 48, 87, 51.5, 84.00000000000001, 87.0, 87.0, 2.256317689530686, 1.0840901398916967, 0.7031161862590252], "isController": false}, {"data": ["Delete Certification", 10, 0, 0.0, 4.3999999999999995, 3, 5, 4.5, 5.0, 5.0, 5.0, 2.321262766945218, 0.4919082230733519, 1.353314327994429], "isController": false}]}, function(index, item){
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
    createTable($("#errorsTable"), {"supportsControllersDiscrimination": false, "titles": ["Type of error", "Number of errors", "% in errors", "% in all samples"], "items": [{"data": ["Test failed: text expected to contain /true/", 3, 75.0, 1.3043478260869565], "isController": false}, {"data": ["500/Internal Server Error", 1, 25.0, 0.43478260869565216], "isController": false}]}, function(index, item){
        switch(index){
            case 2:
            case 3:
                item = item.toFixed(2) + '%';
                break;
        }
        return item;
    }, [[1, 1]]);

        // Create top5 errors by sampler
    createTable($("#top5ErrorsBySamplerTable"), {"supportsControllersDiscrimination": false, "overall": {"data": ["Total", 230, 4, "Test failed: text expected to contain /true/", 3, "500/Internal Server Error", 1, "", "", "", "", "", ""], "isController": false}, "titles": ["Sample", "#Samples", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors"], "items": [{"data": [], "isController": false}, {"data": [], "isController": false}, {"data": ["Add Languages", 10, 1, "Test failed: text expected to contain /true/", 1, "", "", "", "", "", "", "", ""], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": ["Update Languages", 10, 2, "Test failed: text expected to contain /true/", 2, "", "", "", "", "", "", "", ""], "isController": false}, {"data": ["Delete Languages", 10, 1, "500/Internal Server Error", 1, "", "", "", "", "", "", "", ""], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}]}, function(index, item){
        return item;
    }, [[0, 0]], 0);

});
