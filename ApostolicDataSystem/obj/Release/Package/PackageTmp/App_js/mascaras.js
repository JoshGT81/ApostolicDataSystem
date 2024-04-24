$(function () {
    'use strict';

    /// Máscara para telefonos US
    $('.phone-mask-US').toArray().forEach(function (field) {
        new Cleave(field, {
            phone: true,
            phoneRegionCode: 'US'
        });
    });

    /// Máscara para telefono
    $('.phone-mask').toArray().forEach(function (field) {
        new Cleave(field, {
            numericOnly: true,
            blocks: [0, 1, 0, 3, 0, 3, 4],
            delimiters: ["+", " ", "(", ")", " ", "-"]
        });
    });

    /// Máscara para estatura
    $('.estatura-mask').toArray().forEach(function (field) {
        new Cleave(field, {
            numericOnly: true,
            blocks: [1, 0, 2, 0],
            delimiters: ['ft', ' ', 'in']
        });
    });

    /// Máscara para estatura
    $('.momeda-mask').toArray().forEach(function (field) {
        new Cleave(field, {
            numeral: true,
            numeralDecimalMark: '.',
            delimiter: ','
        });
    });

    /// Máscara para permitir solo números
    $('.int-number-mask').toArray().forEach(function (field) {
        new Cleave(field, {
            blocks: [32],
            numericOnly: true,
        })
    });
});