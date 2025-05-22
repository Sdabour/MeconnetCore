function AddCacheInstallmentPayment(intInstallmentID) {

    var vrPayment = GetInstallmentCachePayment(intInstallmentID);
    if (vrPayment.Value == 0) {
        alert("حدد القيمة");
        return;
    }
    if (vrPayment.Value > vrPayment.Installment.Remaining) {
        return;
    }
    if (!confirm("هل تود سداد مبلغ "+ vrPayment.Value))
        return;
    UploadInstallmentPayment(vrPayment);
    FillReservationSimpleInstallment();
}
function AddInstallmentPayment()
{

    var vrPayment = GetInstallmentPayment();
    if (vrPayment.Value == 0) {
        alert("حدد القيمة");
        return;
    }
    if (vrPayment.Type == 1 && vrPayment.CheckID == 0)
    {
        alert("فضلا حدد الشيك");
        return;
    }
    if (!confirm("هل تود سداد مبلغ " + vrPayment.Value))
        return;

    UploadInstallmentPayment(vrPayment);
    FillReservationSimpleInstallment();
}
function UploadInstallmentPayment(vrPayment)
{
   
    var vrPaymentStr = JSON.stringify(vrPayment);
    var vrServiceUrl = "../api/PaymentAPI/AddInstallmentPayment";
    $.ajax({
        method: 'POST',

        url: vrServiceUrl,
        async: false,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: vrPaymentStr,
        success: successFunc,
        error: errorFunc
    });



    function successFunc(data, status) {

    }
    function errorFunc(jqXHR, textStatus, errorThrown) {

    }
}


function DeletePayment(vrPaymentID) {

    //var vrPaymentStr = JSON.stringify(vrPayment);
    var vrServiceUrl = "../api/PaymentAPI/DeletePayment";
    $.ajax({
        method: 'GET',

        url: vrServiceUrl,
        async: true,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: {intPaymentID:vrPaymentID,intDelete:0},
        success: successFunc,
        error: errorFunc
    });



    function successFunc(data, status)
    {
        FillReservationSimpleInstallment();
    }
    function errorFunc(jqXHR, textStatus, errorThrown)
    {

    }
    ClosePaymentModal();
   
}
function CollectPayment(vrPaymentID) {

    var vrPayment = new PaymentSimple();
    vrPayment = GetPaymentForCollection(vrPaymentID);
   var vrPaymentStr = JSON.stringify(vrPayment);
    var vrServiceUrl = "../api/PaymentAPI/CollectPayment";
    $.ajax({
        method: 'POST',

        url: vrServiceUrl,
        async: true,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: vrPaymentStr,
        success: successFunc,
        error: errorFunc
    });



    function successFunc(data, status) {
        FillReservationSimpleInstallment();
    }
    function errorFunc(jqXHR, textStatus, errorThrown) {

    }
    ClosePaymentModal();

}

function AddInstallmentDiscountUpload(vrDiscount) {

    var vrDiscountStr = JSON.stringify(vrDiscount);
    var vrServiceUrl = "../api/PaymentAPI/AddDiscount";
    $.ajax({
        method: 'POST',

        url: vrServiceUrl,
        async: false,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: vrDiscountStr,
        success: successFunc,
        error: errorFunc
    });



    function successFunc(data, status) {

    }
    function errorFunc(jqXHR, textStatus, errorThrown) {

    }
}

function AddInstallmentDiscount(intInstallmentID) {

    var vrPayment = GetInstallmentDiscount(intInstallmentID);
    if (vrPayment.Value == 0) {
        alert("حدد القيمة");
        return;
    }
    if (vrPayment.Desc == "") {
        alert("حدد وصف");
        return;
    }
    if (!confirm("هل تود خصم مبلغ " + vrPayment.Value))
        return;

    AddInstallmentDiscountUpload(vrPayment);
    FillReservationSimpleInstallment();

}

function DeleteDiscount(vrDiscountID,vrInstallmentID) {

    //var vrDiscountStr = JSON.stringify(vrDiscount);
    var vrServiceUrl = "../api/PaymentAPI/DeleteDiscount";
    $.ajax({
        method: 'GET',

        url: vrServiceUrl,
        async: true,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: { intDiscountID: vrDiscountID, intInstallmentID :vrInstallmentID},
        success: successFunc,
        error: errorFunc
    });



    function successFunc(data, status) {
        FillReservationSimpleInstallment();
    }
    function errorFunc(jqXHR, textStatus, errorThrown) {

    }
    CloseDiscountModal();
    
}