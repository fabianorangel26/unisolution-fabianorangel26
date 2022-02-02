var App = App || {};
(function () {

    var appLocalizationSource = abp.localization.getSource('FabianoRangel26');
    App.localize = function () {
        return appLocalizationSource.apply(this, arguments);
    };

})(App);