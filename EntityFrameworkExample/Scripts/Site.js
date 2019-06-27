function hideContents(i) {
    $('#content' + i).val('');
    $('#content' + i).hide();
}
function showContents(i) {
    $('#content' + i).show();
}
function hideAdd(i) {
    $('#add' + i).hide();
}
function showAdd(i) {
    $('#add' + i).show();
}
window.onload = function () {
    $('#content' + 2).hide();
    $('#content' + 3).hide();
    $('#content' + 4).hide();
    $('#content' + 5).hide();
};
$(document).on('submit', function () {
    $('#content' + 1).val($('#input' + 1).val() +
        $('#input' + 2).val() +
        $('#input' + 3).val() +
        $('#input' + 4).val() +
        $('#input' + 5).val());

});
function submitt() {
    alert($('#input' + 1).val() +', '+
        $('#input' + 2).val() + ', ' +
        $('#input' + 3).val() + ', ' +
        $('#input' + 4).val() + ', ' +
        $('#input' + 5).val());
    $('#input' + 1).val($('#input' + 1).val() + ', ' +
        $('#input' + 2).val() + ', ' +
        $('#input' + 3).val() + ', ' +
        $('#input' + 4).val() + ', ' +
        $('#input' + 5).val());
    $("form:first").submit();
}