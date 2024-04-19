function mostrarSweetAlert(tipoAlerta, titulo, texto, href, pie, tipoRedirect) {
    var footer = '';

    if (pie != null) {
        if (pie.length > 0) {
            footer = '<div class="row"><div class="col-md-12"><a data-bs-toggle="collapse" href="#collapseDetalles" role="button" aria-expanded="true" aria-controls="collapseExample"><p class="text-center">Detalles...</p></a><div class="collapse mt-2" id="collapseDetalles"><p class="text-left" style="word-break: break-all;">' + pie + '</p></div></div></div>';
        }
    }

    if (href != null) {
        if (href.length > 0) {
            Swal.fire({
                icon: '' + tipoAlerta + '',
                title: '' + titulo + '',
                text: '' + texto + '',
                position: 'center',
                confirmButtonText: 'Accept',
                allowOutsideClick: false,
                footer: '' + footer + '',
                showCancelButton: false,
            }).then(function (isConfirm) {
                if (tipoAlerta == 'success') {
                    if (tipoRedirect.length > 0) {
                        if (tipoRedirect === "_self") {
                            window.location.href = href;
                        }
                        else {
                            window.open(href, '' + tipoRedirect + '');
                        }
                    }
                    else {
                        window.location.href = href;
                    }
                }
            });
        }
        else {
            Swal.fire({
                icon: '' + tipoAlerta + '',
                title: '' + titulo + '',
                text: '' + texto + '',
                position: 'center',
                confirmButtonText: 'Accept',
                allowOutsideClick: false,
                footer: '' + footer + '',
                showCancelButton: false
            });
        }
    }
    else {
        Swal.fire({
            icon: '' + tipoAlerta + '',
            title: '' + titulo + '',
            text: '' + texto + '',
            position: 'center',
            confirmButtonText: 'Accept',
            allowOutsideClick: false,
            showCancelButton: false,
            footer: '' + footer + ''
        });
    }
}