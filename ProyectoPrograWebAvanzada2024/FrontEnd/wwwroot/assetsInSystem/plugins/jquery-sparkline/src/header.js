(function (document, Math, undefined) {
    (function (factory) {
        if (typeof define === 'function' && define.amd) {
            define(['jquery'], factory);
        } else if (jQuery && !jQuery.fn.sparkline) {
            factory(jQuery);
        }
    })(function ($) {
        'use strict';

        var UNSET_OPTION = {},
            getDefaults, createClass, SPFormat, clipval, quartile, normalizeValue, normalizeValues,
            remove, isNumber, all, sum, addCSS, ensureArray, formatNumber, RangeMap,
            MouseHandler, Tooltip, barHighlightMixin,
            line, bar, tristate, discrete, bullet, pie, box, defaultStyles, initStyles,
            VShape, VCanvas_base, VCanvas_canvas, VCanvas_vml, pending, shapeCount = 0;


    });
})(document, Math);