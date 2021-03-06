System.register(["@angular/core", "@angular/forms", "@angular/router", "./auth.service"], function (exports_1, context_1) {
    "use strict";
    var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
        var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
        else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        return c > 3 && r && Object.defineProperty(target, key, r), r;
    };
    var __metadata = (this && this.__metadata) || function (k, v) {
        if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
    };
    var __moduleName = context_1 && context_1.id;
    var core_1, forms_1, router_1, auth_service_1, LoginComponent;
    return {
        setters: [
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (forms_1_1) {
                forms_1 = forms_1_1;
            },
            function (router_1_1) {
                router_1 = router_1_1;
            },
            function (auth_service_1_1) {
                auth_service_1 = auth_service_1_1;
            }
        ],
        execute: function () {
            LoginComponent = (function () {
                function LoginComponent(fb, router, authService) {
                    this.fb = fb;
                    this.router = router;
                    this.authService = authService;
                    this.title = "Login";
                    this.loginForm = null;
                    this.loginError = false;
                    this.externalProviderWindow = null;
                    this.loginForm = fb.group({
                        username: ["", forms_1.Validators.required],
                        password: ["", forms_1.Validators.required]
                    });
                }
                LoginComponent.prototype.performLogin = function (e) {
                    var _this = this;
                    e.preventDefault();
                    var username = this.loginForm.value.username;
                    var password = this.loginForm.value.password;
                    this.authService.login(username, password)
                        .subscribe(function (data) {
                        // login successful
                        _this.loginError = false;
                        var auth = _this.authService.getAuth();
                        alert("Our Token is: " + auth.access_token);
                        _this.router.navigate([""]);
                    }, function (err) {
                        console.log(err);
                        // login failure
                        _this.loginError = true;
                    });
                };
                LoginComponent.prototype.onRegister = function () {
                    this.router.navigate(["register"]);
                };
                LoginComponent.prototype.callExternalLogin = function (providerName) {
                    var url = "api/Accounts/ExternalLogin/" + providerName;
                    // minimalistic mobile devices support
                    var w = (screen.width >= 1050) ? 1050 : screen.width;
                    var h = (screen.height >= 550) ? 550 : screen.height;
                    var params = "toolbar=yes,scrollbars=yes,resizable=yes,width=" + w + ", height=" + h;
                    // close previously opened windows (if any)
                    if (this.externalProviderWindow) {
                        this.externalProviderWindow.close();
                    }
                    this.externalProviderWindow = window.open(url, "ExternalProvider", params, false);
                };
                return LoginComponent;
            }());
            LoginComponent = __decorate([
                core_1.Component({
                    selector: "login",
                    template: "\n<div class=\"login-container\">\n    <h2 class=\"form-login-heading\">Login</h2>\n    <div class=\"alert alert-danger\" role=\"alert\" *ngIf=\"loginError\">\n        <strong>Warning:</strong> Username or Password mismatch\n    </div>\n    <form class=\"form-login\" [formGroup]=\"loginForm\" (submit)=\"performLogin($event)\">\n        <input formControlName=\"username\" type=\"text\" class=\"form-control\" placeholder=\"Your username or e-mail address\" required autofocus />\n        <input formControlName=\"password\" type=\"password\" class=\"form-control\" placeholder=\"Your password\" required />\n        <div class=\"checkbox\">\n            <label>\n                <input type=\"checkbox\" value=\"remember-me\">\n                Remember me\n            </label>\n        </div>\n        <button class=\"btn btn-lg btn-primary btn-block\" type=\"submit\">Sign in</button>\n    </form>\n    <div class=\"register-link\">\n        Don't have an account yet?\n        <a (click)=\"onRegister()\">Click here to register!</a>\n    </div>\n    <button class=\"btn btn-sm btn-default btn-block\" type=\"submit\" (click)=\"callExternalLogin('Facebook')\">\n        Login with Facebook\n    </button>\n    <button class=\"btn btn-sm btn-default btn-block\" type=\"submit\" (click)=\"callExternalLogin('Google')\">\n        Login with Google\n    </button>\n    <button class=\"btn btn-sm btn-default btn-block\" type=\"submit\" (click)=\"callExternalLogin('Twitter')\">\n        Login with Twitter\n    </button>\n</div>\n    "
                }),
                __metadata("design:paramtypes", [forms_1.FormBuilder,
                    router_1.Router,
                    auth_service_1.AuthService])
            ], LoginComponent);
            exports_1("LoginComponent", LoginComponent);
        }
    };
});
