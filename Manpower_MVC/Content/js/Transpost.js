$.fn.dataTable.Editor.display.lightbox.conf.windowPadding = 70;

// replace all function
String.prototype.replaceAll = function (search, replacement) {
    var target = this;
    return target.split(search).join(replacement);
};

editor = new $.fn.dataTable.Editor({
    ajax: {
        create: {
            type: "POST",
            url: "../api/transport/create",
        },
        edit: {
            type: "PUT",
            url: "../api/transport/Edit",
        },
        remove: {
            type: "POST",
            url: "../api/transport/remove",
        }
    },
    table: "#example",
    idSrc: 'TransportId',
    template: '#customForm1',
    formOptions: {
        main: {
            focus: 1
        }
    },
    fields: [{
        label: "日期:",
        name: "Date",
        type: "datetime",
        //dateFormat: "yyyy/mm/dd",
        def: function () { return new Date(); },
        format: "YYYY/MM/DD HH:mm",
        attr: {
            tabIndex: 1
        }
    }, {
        label: "車牌號碼:",
        name: "CargoId",
        attr: {
            tabIndex: 2
        }
    }, {
        label: "車主姓名:",
        name: "Driver",
        type: "readonly"
    }, {
        label: "客戶編號:",
        name: "CustomerId",
        attr: {
            tabIndex: 4
        }
    }, {
        label: "貨主:",
        name: "GoodsOwner",
        attr: {
            tabIndex: 5
        }
    }, {
        label: "開出地點編號:",
        name: "StartPlaceId",
        attr: {
            tabIndex: 6
        }
    }, {
        label: "到達地點編號:",
        name: "ArrivalPlaceId",
        attr: {
            tabIndex: 7
        }
    }, {
        label: "請款類別:",
        name: "InvoiceType",
        attr: {
            type: "number", placeholder: "1.貨櫃 2.貨運 3.船名", tabIndex: 8
        }
    }, {
        label: "船名:",
        name: "ShipName",
        attr: {
            tabIndex: 9
        }
    }, {
        label: "貨運號碼:",
        name: "ContainerNumber",
        attr: {
            tabIndex: 10
        }
    }, {
        label: "托運號碼:",
        name: "CheckedNumber",
        attr: {
            tabIndex: 11
        }
    }, {
        label: "貨品代號:",
        name: "ItemId",
        attr: {
            tabIndex: 16
        }
    }, {
        label: "貨品數量:",
        name: "ItemQuantity",
        attr: {
            type: "number", tabIndex: 17
        }
    }, {
        label: "貨品單位:",
        name: "ItemUnit",
        type: "readonly"
    }, {
        label: "請款單價:",
        name: "InvoiceUnitPrice",
        attr: {
            type: "number", tabIndex: 19
        }
    }, {
        label: "請款加減:",
        name: "InvoicOtherPrice",
        attr: {
            type: "number", tabIndex: 20
        },
        default: 0,
    }, {
        label: "請款合計:",
        name: "InvoiceTotal",
        attr: {
            type: "number"
        },
        type: "readonly"
    }, {
        label: "請款備註:",
        name: "InvoiceMemo",
        attr: {
            tabIndex: 22
        }
    }, {
        label: "付款單價:",
        name: "PayUnitPrice",
        attr: {
            type: "number", tabIndex: 23
        }
    }, {
        label: "付款加減:",
        name: "PayOtherPrice",
        attr: {
            type: "number", tabIndex: 24
        },
        default: 0,
    }, {
        label: "付款合計:",
        name: "PayTotal",
        attr: {
            type: "number"
        },
        type: "readonly"
    }, {
        label: "付款備註:",
        name: "PayMemo",
        attr: {
            tabIndex: 26
        }
    }, {
        type: "checkbox",
        //label: "領:",
        name: "Take",
        options: [
            { label: '領', value: true }
        ],
        separator: '',
        unselectedValue: false,
        attr: {
            tabIndex: "12",
            style: "margin-left :15px;"
        }
    }, {
        type: "checkbox",
        name: "Transmit",
        separator: "|",
        options: [
            { label: '送', value: true }
        ],
        separator: '',
        unselectedValue: false,
        attr: {
            tabIndex: 13,
            style: "margin-left :15px;"
        }
    }, {
        type: "checkbox",
        name: "Receive",
        separator: "|",
        options: [
            { label: '收', value: true }
        ],
        separator: '',
        unselectedValue: false,
        attr: {
            tabIndex: 14,
            style: "margin-left :15px;"
        }
    }, {
        type: "checkbox",
        name: "HandOver",
        separator: "|",
        options: [
            { label: '繳', value: true }
        ],
        separator: '',
        unselectedValue: false,
        attr: {
            tabIndex: 15,
            style: "margin-left :15px;"
        }
    }, {
        label: "利潤分析:",
        name: "Profit",
        type: "readonly"
    }
    ],
    i18n: {
        //    // https://editor.datatables.net/reference/option/i18n
        create: {
            button: "create",
            title: "新增貨運運輸請款資料",
            submit: "新增"
        },
        edit: {
            button: "edit",
            title: "修改貨運運輸請款資料",
            submit: "更新"
        },
        remove: {
            button: "delete",
            title: "刪除貨運運輸請款資料",
            submit: "刪除",
            confirm: {
                "_": "您確定要刪除 %d 筆資料?",
                "1": "您確定要刪除 1 筆資料?"
            }
        },
        datetime: {
            previous: '上',
            next: '下',
            months: ['一月', '二月', '三月', '四月', '五月', '六月', '七月', '八月', '九月', '十月', '十一月', '十二月'],
            weekdays: ['星期日', '星期一', '星期二', '星期三', '星期四', '星期五', '星期六']
        }
    }
});

editor.on( 'create', function ( e, json, data ) {
    editor.field("CargoId").def(data.CargoId);
    editor.field("CustomerId").def(data.CustomerId);
    editor.field("GoodsOwner").def(data.GoodsOwner);
    editor.field("StartPlaceId").def(data.StartPlaceId);
    editor.field("ArrivalPlaceId").def(data.ArrivalPlaceId);

    updateAll();
});

// 自動帶出車主姓名
editor.field('CargoId').input().on('blur', function (e, d) {
    if (d && d.editorSet) return;

    showDriver();
});

function showDriver() {
    editor.field('Driver').val("");
    viewModel.CargoList.forEach(function (item) {
        if (item.CargoId == editor.field('CargoId').val()) {
            editor.field('Driver').val(item.Driver);
        }
    })
}

//// 自動帶出客戶簡稱
editor.field('CustomerId').input().on('blur', function (e, d) {
    if (d && d.editorSet) return;

    showCustShortName();
});

function showCustShortName() {
    editor.field('CustomerId').message("");
    viewModel.CustomerList.forEach(function (item) {
        if (item.CustomerId == editor.field('CustomerId').val()) {
            editor.field('CustomerId').message(item.CustName);
        }
    })
}

// 自動帶出開出地點
editor.field('StartPlaceId').input().on('blur', function (e, d) {
    if (d && d.editorSet) return;

    showStartPlace();
});

function showStartPlace() {
    editor.field('StartPlaceId').message("");
    viewModel.PlaceList.forEach(function (item) {
        if (item.PlaceId == editor.field('StartPlaceId').val()) {
            editor.field('StartPlaceId').message(item.PlaceName);
            //$("#lblStartPlace").text(item.PlaceName);
        }
    })
}

// 自動帶出到達地點
editor.field('ArrivalPlaceId').input().on('blur', function (e, d) {
    if (d && d.editorSet) return;

    showArrivalPlace();
});

function showArrivalPlace() {
    editor.field('ArrivalPlaceId').message("");
    viewModel.PlaceList.forEach(function (item) {
        if (item.PlaceId == editor.field('ArrivalPlaceId').val()) {
            editor.field('ArrivalPlaceId').message(item.PlaceName);
            //$("#lblArrivalPlace").text(item.PlaceName);
        }
    })
}

// 自動帶出貨品名稱及單位
editor.field('ItemId').input().on('blur', function (e, d) {
    if (d && d.editorSet) return;

    showItemNameAndUnit();
});


function showItemNameAndUnit() {
    editor.field('ItemId').message("");
    editor.field('ItemUnit').val("");
    viewModel.ItemList.forEach(function (item) {
        if (item.ItemId == editor.field('ItemId').val()) {
            editor.field('ItemId').message(item.ItemName, false);
            editor.field('ItemUnit').val(item.Unit);
        }
    })
}

// 自動計算請款
function calcInvoiceTotal() {
    editor.field('InvoiceTotal').val("");
    if (editor.field('ItemQuantity').val() != '' &&
        editor.field('InvoiceUnitPrice').val() != '') {
        var total = Math.round(((Number(editor.field('ItemQuantity').val()) * Number(editor.field('InvoiceUnitPrice').val())) + Number(editor.field('InvoicOtherPrice').val())) * 1.05);
        editor.field('InvoiceTotal').val(total);
        calcProfit();
    }
}

// 自動計算付款
function calcPayTotal() {
    editor.field('PayTotal').val("");
    if (editor.field('ItemQuantity').val() != '' &&
        editor.field('PayUnitPrice').val() != '') {
        var total = Math.round(((Number(editor.field('ItemQuantity').val()) * Number(editor.field('PayUnitPrice').val())) + Number(editor.field('PayOtherPrice').val())) * 0.9);
        editor.field('PayTotal').val(total);
        calcProfit();
    }
}

// 自動計算利潤
function calcProfit() {
    editor.field('Profit').val("");
    if (editor.field('InvoiceTotal').val() != '' &&
        editor.field('PayTotal').val() != '') {
        var profit = Number(editor.field('InvoiceTotal').val()) - Number(editor.field('PayTotal').val());
        editor.field('Profit').val(profit);
    }
}

editor.field('ItemQuantity').input().on('keyup change blur', function (e, d) {
    if (d && d.editorSet) return;

    calcInvoiceTotal();
    calcPayTotal();
});


editor.field('InvoiceUnitPrice').input().on('keyup change blur', function (e, d) {
    if (d && d.editorSet) return;

    calcInvoiceTotal();
});

editor.field('InvoicOtherPrice').input().on('keyup change blur', function (e, d) {
    if (d && d.editorSet) return;

    calcInvoiceTotal();
});


editor.field('PayUnitPrice').input().on('keyup change blur', function (e, d) {
    if (d && d.editorSet) return;

    calcPayTotal();
});

editor.field('PayOtherPrice').input().on('keyup change blur', function (e, d) {
    if (d && d.editorSet) return;

    calcPayTotal();
});

editor.on('open', function () {
    editor.field('Date').val(editor.field('Date').val().replaceAll("-", "/").replace("T", " ").substring(0, 16));
    updateAll();
});

function updateAll() {
    showDriver();
    showCustShortName();
    showStartPlace();
    showArrivalPlace();
    showItemNameAndUnit();
}