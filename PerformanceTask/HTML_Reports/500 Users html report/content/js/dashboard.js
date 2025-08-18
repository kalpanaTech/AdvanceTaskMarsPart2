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

    var data = {"OkPercent": 99.9304347826087, "KoPercent": 0.06956521739130435};
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
    createTable($("#apdexTable"), {"supportsControllersDiscrimination": true, "overall": {"data": [0.9993043478260869, 500, 1500, "Total"], "isController": false}, "titles": ["Apdex", "T (Toleration threshold)", "F (Frustration threshold)", "Label"], "items": [{"data": [1.0, 500, 1500, "SignOut"], "isController": false}, {"data": [1.0, 500, 1500, "Update Skills"], "isController": false}, {"data": [0.998, 500, 1500, "Add Languages"], "isController": false}, {"data": [1.0, 500, 1500, "Add Education"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Education"], "isController": false}, {"data": [1.0, 500, 1500, "Add Certification"], "isController": false}, {"data": [1.0, 500, 1500, "Add Description"], "isController": false}, {"data": [1.0, 500, 1500, "View Manage Listings"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Skills"], "isController": false}, {"data": [1.0, 500, 1500, "Share Skills"], "isController": false}, {"data": [1.0, 500, 1500, "Search Skills"], "isController": false}, {"data": [1.0, 500, 1500, "Enable Manage Listings"], "isController": false}, {"data": [0.992, 500, 1500, "Update Languages"], "isController": false}, {"data": [0.998, 500, 1500, "Delete Languages"], "isController": false}, {"data": [0.998, 500, 1500, "Update Education"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Share Skills"], "isController": false}, {"data": [1.0, 500, 1500, "Disable Manage Listings"], "isController": false}, {"data": [1.0, 500, 1500, "Add Skills"], "isController": false}, {"data": [0.998, 500, 1500, "Update Certification"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Manage Listings"], "isController": false}, {"data": [1.0, 500, 1500, "Add Manage Listings"], "isController": false}, {"data": [1.0, 500, 1500, "SignIn"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Certification"], "isController": false}]}, function(index, item){
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
    createTable($("#statisticsTable"), {"supportsControllersDiscrimination": true, "overall": {"data": ["Total", 11500, 8, 0.06956521739130435, 6.998695652173863, 2, 238, 5.0, 7.0, 11.0, 57.0, 229.5684113865932, 49.09438224887212, 160.1551193131912], "isController": false}, "titles": ["Label", "#Samples", "FAIL", "Error %", "Average", "Min", "Max", "Median", "90th pct", "95th pct", "99th pct", "Transactions/s", "Received", "Sent"], "items": [{"data": ["SignOut", 500, 0, 0.0, 2.7979999999999996, 2, 20, 3.0, 3.0, 4.0, 4.0, 10.04419445560466, 2.0381083015267176, 5.463492491964645], "isController": false}, {"data": ["Update Skills", 500, 0, 0.0, 6.455999999999997, 4, 29, 6.0, 8.0, 9.0, 13.0, 10.02104419280489, 2.025738425693957, 6.429517611985168], "isController": false}, {"data": ["Add Languages", 500, 1, 0.2, 3.316000000000001, 2, 19, 3.0, 4.0, 4.0, 6.0, 10.028883183568679, 2.0280086336148107, 5.9154740653080875], "isController": false}, {"data": ["Add Education", 500, 0, 0.0, 3.4359999999999973, 2, 14, 3.0, 4.0, 5.0, 6.990000000000009, 10.03129764866383, 2.0278111457748174, 6.857332377016291], "isController": false}, {"data": ["Delete Education", 500, 0, 0.0, 3.7140000000000004, 2, 12, 4.0, 5.0, 5.0, 7.0, 10.033914631454316, 2.1361263570869538, 5.8106556410668055], "isController": false}, {"data": ["Add Certification", 500, 0, 0.0, 3.5339999999999963, 2, 63, 3.0, 4.0, 5.0, 6.0, 10.03472013165553, 2.0285029953639593, 6.536287429506091], "isController": false}, {"data": ["Add Description", 500, 0, 0.0, 4.938000000000002, 2, 11, 5.0, 6.0, 7.0, 8.0, 10.036331520102772, 2.1484022160219993, 6.21390057006363], "isController": false}, {"data": ["View Manage Listings", 500, 0, 0.0, 3.0879999999999987, 2, 28, 3.0, 4.0, 4.0, 5.0, 10.043185698503565, 2.037903610525259, 5.865063523149543], "isController": false}, {"data": ["Delete Skills", 500, 0, 0.0, 3.8259999999999996, 2, 30, 4.0, 5.0, 5.0, 7.0, 10.023454884429565, 1.8989748511516948, 6.431064315498266], "isController": false}, {"data": ["Share Skills", 500, 0, 0.0, 5.924, 4, 31, 6.0, 7.0, 7.0, 9.0, 10.036331520102772, 2.1954475200224812, 17.612585685180353], "isController": false}, {"data": ["Search Skills", 500, 0, 0.0, 2.972000000000001, 2, 11, 3.0, 4.0, 4.0, 5.0, 10.043790928448034, 2.0380264201920375, 5.973309253344583], "isController": false}, {"data": ["Enable Manage Listings", 500, 0, 0.0, 5.542000000000001, 4, 26, 5.0, 7.0, 7.0, 9.0, 10.042782252395204, 1.8634068632373912, 5.688294635145721], "isController": false}, {"data": ["Update Languages", 500, 4, 0.8, 6.222000000000001, 3, 17, 6.0, 8.0, 9.0, 12.990000000000009, 10.028883183568679, 2.107358254272304, 6.228543674532654], "isController": false}, {"data": ["Delete Languages", 500, 1, 0.2, 3.5980000000000008, 2, 19, 3.0, 5.0, 5.0, 6.990000000000009, 10.030895157083817, 1.928028170515187, 5.798778205623321], "isController": false}, {"data": ["Update Education", 500, 1, 0.2, 6.344000000000001, 3, 68, 6.0, 8.0, 9.0, 13.0, 10.032102728731942, 2.135838589737159, 7.210573836276083], "isController": false}, {"data": ["Delete Share Skills", 500, 0, 0.0, 6.766000000000003, 5, 48, 6.0, 8.0, 8.0, 11.990000000000009, 10.040967145955499, 2.000348923608322, 5.7461003393846894], "isController": false}, {"data": ["Disable Manage Listings", 500, 0, 0.0, 5.523999999999999, 4, 18, 5.0, 7.0, 7.0, 10.0, 10.042983971397582, 1.8536366900333427, 5.688408890049411], "isController": false}, {"data": ["Add Skills", 500, 0, 0.0, 4.705999999999996, 3, 12, 5.0, 6.0, 6.0, 9.990000000000009, 10.02004008016032, 2.0255354458917836, 6.252739854709419], "isController": false}, {"data": ["Update Certification", 500, 1, 0.2, 6.798000000000006, 4, 59, 7.0, 8.0, 9.0, 11.990000000000009, 10.034115994380896, 1.715755443507927, 6.957248394541441], "isController": false}, {"data": ["Delete Manage Listings", 500, 0, 0.0, 6.983999999999994, 5, 26, 7.0, 8.0, 9.0, 16.0, 10.041773778920309, 1.9808967806073263, 5.746561947702442], "isController": false}, {"data": ["Add Manage Listings", 500, 0, 0.0, 4.563999999999997, 3, 12, 4.0, 5.0, 6.0, 8.990000000000009, 10.042580541495942, 2.1968144934522376, 17.603937570298065], "isController": false}, {"data": ["SignIn", 500, 0, 0.0, 55.90600000000003, 47, 238, 54.0, 61.900000000000034, 68.0, 95.97000000000003, 10.007205187735169, 4.808149367544632, 3.1349133876391004], "isController": false}, {"data": ["Delete Certification", 500, 0, 0.0, 4.013999999999999, 2, 56, 4.0, 5.0, 5.0, 6.0, 10.0357271887921, 2.1266529156296414, 5.850907355184456], "isController": false}]}, function(index, item){
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
    createTable($("#errorsTable"), {"supportsControllersDiscrimination": false, "titles": ["Type of error", "Number of errors", "% in errors", "% in all samples"], "items": [{"data": ["Test failed: text expected to contain /true/", 7, 87.5, 0.06086956521739131], "isController": false}, {"data": ["500/Internal Server Error", 1, 12.5, 0.008695652173913044], "isController": false}]}, function(index, item){
        switch(index){
            case 2:
            case 3:
                item = item.toFixed(2) + '%';
                break;
        }
        return item;
    }, [[1, 1]]);

        // Create top5 errors by sampler
    createTable($("#top5ErrorsBySamplerTable"), {"supportsControllersDiscrimination": false, "overall": {"data": ["Total", 11500, 8, "Test failed: text expected to contain /true/", 7, "500/Internal Server Error", 1, "", "", "", "", "", ""], "isController": false}, "titles": ["Sample", "#Samples", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors"], "items": [{"data": [], "isController": false}, {"data": [], "isController": false}, {"data": ["Add Languages", 500, 1, "Test failed: text expected to contain /true/", 1, "", "", "", "", "", "", "", ""], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": ["Update Languages", 500, 4, "Test failed: text expected to contain /true/", 4, "", "", "", "", "", "", "", ""], "isController": false}, {"data": ["Delete Languages", 500, 1, "500/Internal Server Error", 1, "", "", "", "", "", "", "", ""], "isController": false}, {"data": ["Update Education", 500, 1, "Test failed: text expected to contain /true/", 1, "", "", "", "", "", "", "", ""], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": ["Update Certification", 500, 1, "Test failed: text expected to contain /true/", 1, "", "", "", "", "", "", "", ""], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}]}, function(index, item){
        return item;
    }, [[0, 0]], 0);

});
