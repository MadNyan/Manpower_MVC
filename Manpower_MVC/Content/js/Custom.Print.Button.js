
var _link = document.createElement('a');

/**
 * Clone link and style tags, taking into account the need to change the source
 * path.
 *
 * @param  {node}     el Element to convert
 */
var _styleToAbs = function (el) {
	var url;
	var clone = $(el).clone()[0];
	var linkHost;

	if (clone.nodeName.toLowerCase() === 'link') {
		clone.href = _relToAbs(clone.href);
	}

	return clone.outerHTML;
};

/**
 * Convert a URL from a relative to an absolute address so it will work
 * correctly in the popup window which has no base URL.
 *
 * @param  {string} href URL
 */
var _relToAbs = function (href) {
	// Assign to a link on the original page so the browser will do all the
	// hard work of figuring out where the file actually is
	_link.href = href;
	var linkHost = _link.host;

	// IE doesn't have a trailing slash on the host
	// Chrome has it on the pathname
	if (linkHost.indexOf('/') === -1 && _link.pathname.indexOf('/') !== 0) {
		linkHost += '/';
	}

	return _link.protocol + "//" + linkHost + _link.pathname + _link.search;
};

$.fn.dataTable.ext.buttons.customizePrintInvoice = {
	className: 'buttons-print',
    text: '列印請款單',
    action: function (e, dt, button, config) {
    	var data = dt.buttons.exportData(config.exportOptions);
    	data.header.shift();
    	var addRow = function (d, tag) {
    		var str = '<tr>';

    		for (var i = 0, ien = d.length ; i < ien ; i++) {
    			if (tag == "td") {
    				if (!isNaN(d[i])) {
    					// 數字置右
    					str += '<' + tag + ' align="right" style="line-height:1px;">' + d[i] + '</' + tag + '>';
    				}
    				else if (d[i] == "Y") {
    					str += '<' + tag + ' align="center" style="line-height:1px;">' + d[i] + '</' + tag + '>';
    				}
    				else {
    					str += '<' + tag + ' style="line-height:1px;">' + d[i] + '</' + tag + '>';
    				}
    			}
    			else {
    				str += '<' + tag + '>' + d[i] + '</' + tag + '>';
    			}
    		}

    		return str + '</tr>';
    	};

    	// show table group by customer
    	var customers = [];
    	var customerId;
    	var addedCustomerId = [];
    	for (var rowIndex = 0; rowIndex < data.body.length; rowIndex++) {
    		customerId = data.body[rowIndex][0];
    		if (addedCustomerId.indexOf(customerId) == -1) {
    			addedCustomerId.push(customerId);
    			for (var custIndex = 0; custIndex < config.customParam.customerList.length; custIndex++) {
    				if (config.customParam.customerList[custIndex].CustomerId == customerId) {
    					//custIndex = config.customParam.customerList.length;
    					customers.push({
    						customerId: customerId,
    						customerName: config.customParam.customerList[custIndex].CustName,
    						address: config.customParam.customerList[custIndex].Address,
    						tel: config.customParam.customerList[custIndex].Tel,
    						uniNumber: config.customParam.customerList[custIndex].CustUniNumber
    					});

    					break;
    				}
    			}
    		}
    	}

    	var tables = [];

    	var title = config.title;

    	if (typeof title === 'function') {
    		title = title();
    	}

    	if (title.indexOf('*') !== -1) {
    		title = title.replace('*', $('title').text());
    	}

    	for (var customerIndex = 0; customerIndex < customers.length; customerIndex++) {
    		var html = '<h1 style="text-align:center;font-size:medium;">' + title + '</h1>' +
			            '<div>' +
				            "<p style='text-align:center;'>住址: 台中縣大雅鄉上楓村民豐街154巷4號5-2&nbsp;&nbsp;&nbsp;&nbsp;電話: (04)25670074&nbsp;&nbsp;&nbsp;&nbsp;傳真: (04)25694071</p>" +
                            "<HR color='#FFFFFF' size='2' width='100%'>" +
                             "<p style='text-align:left;'>客戶名稱:" + customers[customerIndex].customerName + "&nbsp;&nbsp;&nbsp;&nbsp;地址:" + customers[customerIndex].address + "&nbsp;&nbsp;&nbsp;&nbsp;電話號碼:" + customers[customerIndex].tel + "</p></br>" +
                              "<p style='text-align:left;'>起始日期:" + config.customParam.startDatetime() + "&nbsp;&nbsp;&nbsp;&nbsp;截止日期:" + config.customParam.endDatetime() + "&nbsp;&nbsp;&nbsp;&nbsp;統一編號:" + customers[customerIndex].uniNumber + "</p></br>"
			            '</div>';


    		// Construct a table for printing
    		html += '<table class="' + dt.table().node().className + '">';

    		if (config.header) {
    			html += '<thead>' + addRow(data.header, 'th') + '</thead>';
    		}

    		html += '<tbody>';
    		var sum = 0;
    		for (var i = 0, ien = data.body.length ; i < ien ; i++) {
    			if (data.body[i][0] == customers[customerIndex].customerId) {
    				data.body[i].shift();
    				data.body[i][0] = Number(data.body[i][0].substring(0, 4) - 1911) + data.body[i][0].substring(5, 10).replace("/", "");
    				sum += Number(data.body[i][13]);
    				html += addRow(data.body[i], 'td');
    			}
    		}
    		html += '</tbody>';

    		//if (config.footer && data.footer) {
    		//	html += '<tfoot>' + addRow(data.footer, 'th') + '</tfoot>';
    		//}
    		html += '<tfoot><tr><th></th><th></th><th></th><th></th><th></th><th></th><th></th><th></th><th></th><th></th><th></th><th colspan="3" style="line-height:1px;"><p style="display:block;">總計應收:<span style="float:right;text-align:right;">' + Math.round(sum * 1.05) + '</span></p>' + '</th><th></th></tr></tfoot>';
    		html += '<tfoot><tr><th></th><th></th><th></th><th></th><th></th><th></th><th></th><th></th><th></th><th></th><th></th><th colspan="3" style="line-height:1px;"><p style="display:block;">合計:<span style="float:right;text-align:right;">' + sum + '</span></p>' + '</th><th></th></tr></tfoot>';
    		html += '<tfoot><tr><th></th><th></th><th></th><th></th><th></th><th></th><th></th><th></th><th></th><th></th><th></th><th colspan="3" style="line-height:1px;"><p style="display:block;">5%稅額:<span style="float:right;text-align:right;">' + Math.round(sum * 0.05) + '</span></p>' + '</th><th></th></tr></tfoot>';

    		html += '</table>';

    		// new page
    		if (customerIndex != customers.length - 1) {
    			html += '<div style="page-break-before: always;"> </div>';
    		}

    		tables.push(html);
    	}

    	//// Construct a table for printing
    	//var html = '<table class="' + dt.table().node().className + '">';

    	//if (config.header) {
    	//	html += '<thead>' + addRow(data.header, 'th') + '</thead>';
    	//}

    	//html += '<tbody>';
    	//for (var i = 0, ien = data.body.length ; i < ien ; i++) {
    	//	html += addRow(data.body[i], 'td');
    	//}
    	//html += '</tbody>';

    	//if (config.footer && data.footer) {
    	//	html += '<tfoot>' + addRow(data.footer, 'th') + '</tfoot>';
    	//}

    	// Open a new window for the printable table
    	var win = window.open('', '');

    	win.document.close();

    	// Inject the title and also a copy of the style and link tags from this
    	// document so the table can retain its base styling. Note that we have
    	// to use string manipulation as IE won't allow elements to be created
    	// in the host document and then appended to the new window.
    	var head = '<title>' + title + '</title>';
    	$('style, link').each(function () {
    		head += _styleToAbs(this);
    	});

    	try {
    		win.document.head.innerHTML = head; // Work around for Edge
    	}
    	catch (e) {
    		$(win.document.head).html(head); // Old IE
    	}

    	//// Inject the table and other surrounding information
    	//win.document.body.innerHTML =
		//	'<h1>' + title + '</h1>' +
		//	'<div>' +
		//		(typeof config.message === 'function' ?
		//			config.message(dt, button, config) :
		//			config.message
		//		) +
		//	'</div>' +
    	//	html;

    	for (var tableIndex = 0; tableIndex < tables.length; tableIndex++) {
    		win.document.body.innerHTML += tables[tableIndex];
    	}

    	$(win.document.body)
            .addClass('dt-print-view')
    	    .css({
    	    	"line-height": "5px",
    	    	"font-size": "medium"
    	    });

    	$('img', win.document.body).each(function (i, img) {
    		img.setAttribute('src', _relToAbs(img.getAttribute('src')));
    	});

    	if (config.customize) {
    		config.customize(win);
    	}

    	setTimeout(function () {
    		if (config.autoPrint) {
    			win.print(); // blocking - so close will not
    			win.close(); // execute until this is done
    		}
    	}, 250);
    },

    title: '*',

    message: '',

    exportOptions: {},

    header: true,

    footer: false,

    autoPrint: true,

    customize: null,

    customParam: null
};