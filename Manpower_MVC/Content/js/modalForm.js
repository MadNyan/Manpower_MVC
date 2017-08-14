function createSubmit() {
    $('#form').children('#submit').val('新增');
    $('#form').children('#submit').addClass('btn-primary');
    $('#form').children('#submit').removeClass('btn-warning');
}

function editSubmit() {
    $('#form').children('#submit').val('更新');
    $('#form').children('#submit').addClass('btn-warning');
    $('#form').children('#submit').removeClass('btn-primary');
}