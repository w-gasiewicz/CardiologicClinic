// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$('.btn').on('click', function () {
    var $this = $(this);
    $this.button('loading');
    setTimeout(function () {
        $this.button('reset');
    }, 8000);
});