
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

$.fn.dataTable.ext.buttons.customizePrintPay = {
	className: 'buttons-print',
	text: '列印付款明細單',
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
		var cargoIds = [];
		var cargoId;
		var addedCargoId = [];
		for (var rowIndex = 0; rowIndex < data.body.length; rowIndex++) {
		    cargoId = data.body[rowIndex][0];
		    if (addedCargoId.indexOf(cargoId) == - 1) {
		        addedCargoId.push(cargoId);
				for (var custIndex = 0; custIndex < config.customParam.cargoList.length; custIndex++) {
				    if (config.customParam.cargoList[custIndex].CargoId == cargoId) {
					    cargoIds.push({
					        cargoId: cargoId,
							driver: config.customParam.cargoList[custIndex].Driver,
							carDealer: config.customParam.cargoList[custIndex].CarDealer,
							tel: config.customParam.cargoList[custIndex].Tel
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


		for (var cargoIndex = 0; cargoIndex < cargoIds.length; cargoIndex++) {
			var html = '<h1 style="text-align:center;font-size:medium;">' + title + '</h1>' +
			            '<div>' +
				            "<p style='text-align:center;'>住址: 台中縣大雅鄉上楓村民豐街154巷4號5-2&nbsp;&nbsp;&nbsp;&nbsp;電話: (04)25670074&nbsp;&nbsp;&nbsp;&nbsp;傳真: (04)25694071</p>" +
                            "<HR color='#FFFFFF' size='2' width='100%'>" +
                             "<p style='text-align:left;'>車牌號碼:" + cargoIds[cargoIndex].cargoId + "&nbsp;&nbsp;&nbsp;&nbsp;車主:" + cargoIds[cargoIndex].driver + "&nbsp;&nbsp;&nbsp;&nbsp;電話號碼:" + cargoIds[cargoIndex].tel + "&nbsp;&nbsp;&nbsp;&nbsp;車行:" + cargoIds[cargoIndex].carDealer + "</p></br>" +
                              "<p style='text-align:left;'>起始日期:" + config.customParam.startDatetime() + "&nbsp;&nbsp;&nbsp;&nbsp;截止日期:" + config.customParam.endDatetime() + "</p></br>"
			'</div>';


			// Construct a table for printing
			html += '<table class="' + dt.table().node().className + '">';

			if (config.header) {
				html += '<thead>' + addRow(data.header, 'th') + '</thead>';
			}

			html += '<tbody>';
			var sum = 0;
			for (var i = 0, ien = data.body.length ; i < ien ; i++) {
			    if (data.body[i][0] == cargoIds[cargoIndex].cargoId) {
			        data.body[i].shift();
					data.body[i][0] = Number(data.body[i][0].substring(0, 4) - 1911) + data.body[i][0].substring(5, 10).replace("/", "");
					sum += Number(data.body[i][11]);
					html += addRow(data.body[i], 'td');
				}
			}
			html += '</tbody>';

			var totalPay = (sum - Math.round(sum / 10));
			var dis = Math.round(totalPay * (config.interestRate * 0.0001) * config.days);

			html += '<tfoot><tr><th></th><th></th><th></th><th></th><th></th><th></th><th></th><th></th><th></th><th colspan="3" style="line-height:1px;"><p style="display:block;">實付金額:<span style="float:right;text-align:right;">' + (sum - Math.round(sum / 10) - dis) + '</span></p>' + '</th><th></th></tr></tfoot>';
			html += '<tfoot><tr><th></th><th></th><th></th><th></th><th></th><th></th><th></th><th></th><th></th><th colspan="3" style="line-height:1px;"><p style="display:block;">合計:<span style="float:right;text-align:right;">' + sum + '</span></p>' + '</th><th></th></tr></tfoot>';
			html += '<tfoot><tr><th></th><th></th><th></th><th></th><th></th><th></th><th></th><th></th><th></th><th colspan="3" style="line-height:1px;"><p style="display:block;">-<span style="float:right;text-align:right;">' + Math.round(sum / 10) + '</span></p>' + '</th><th></th></tr></tfoot>';
			html += '<tfoot><tr><th></th><th></th><th></th><th></th><th></th><th></th><th></th><th></th><th></th><th colspan="3" style="line-height:1px;"><p style="display:block;">總計應付:<span style="float:right;text-align:right;">' + totalPay + '</span></p>' + '</th><th></th></tr></tfoot>';
			html += '<tfoot><tr><th></th><th></th><th></th><th></th><th></th><th></th><th></th><th></th><th></th><th colspan="3" style="line-height:1px;"><p style="display:block;">-<span style="float:right;text-align:right;">' + dis + '</span></p>' + '</th><th></th></tr></tfoot>';
			
			html += '</table>';

			// new page
			if (cargoIndex != cargoIds.length - 1) {
				html += '<div style="page-break-before: always;"> </div>';
			}

			tables.push(html);
		}

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

	customParam: null,

    interestRate: 7,

    days: 60
};