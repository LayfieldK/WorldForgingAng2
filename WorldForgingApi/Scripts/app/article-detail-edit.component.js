System.register(["@angular/core", "@angular/router", "./article", "./auth.service", "./article.service", "./entity.service", "./relationship.service", "@angular/forms"], function (exports_1, context_1) {
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
    var core_1, router_1, article_1, auth_service_1, article_service_1, entity_service_1, relationship_service_1, forms_1, ArticleDetailEditComponent;
    return {
        setters: [
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (router_1_1) {
                router_1 = router_1_1;
            },
            function (article_1_1) {
                article_1 = article_1_1;
            },
            function (auth_service_1_1) {
                auth_service_1 = auth_service_1_1;
            },
            function (article_service_1_1) {
                article_service_1 = article_service_1_1;
            },
            function (entity_service_1_1) {
                entity_service_1 = entity_service_1_1;
            },
            function (relationship_service_1_1) {
                relationship_service_1 = relationship_service_1_1;
            },
            function (forms_1_1) {
                forms_1 = forms_1_1;
            }
        ],
        execute: function () {
            ArticleDetailEditComponent = (function () {
                function ArticleDetailEditComponent(authService, articleService, entityService, relationshipService, router, activatedRoute, formBuilder) {
                    this.authService = authService;
                    this.articleService = articleService;
                    this.entityService = entityService;
                    this.relationshipService = relationshipService;
                    this.router = router;
                    this.activatedRoute = activatedRoute;
                    this.formBuilder = formBuilder;
                }
                ArticleDetailEditComponent.prototype.ngOnInit = function () {
                    var _this = this;
                    this.editArticleForm = this.formBuilder.group({
                        title: ['', forms_1.Validators.required],
                        description: ['', forms_1.Validators.required],
                        text: ['', forms_1.Validators.required],
                        entityRelationships: this.formBuilder.array([])
                    });
                    this.editEntityRelationshipsForm = this.formBuilder.group({
                        entityRelationships: this.formBuilder.array([this.initEntityRelationship()])
                    });
                    this.relationshipService.getAll().subscribe(function (data) { return _this.relationships = data; }, function (error) { return console.log(error); });
                    this.entityService.getAll().subscribe(function (data) { return _this.entities = data; }, function (error) { return console.log(error); });
                    if (!this.authService.isLoggedIn()) {
                        this.router.navigate([""]);
                    }
                    var id;
                    this.activatedRoute.params
                        .map(function (params) { return +params['id']; })
                        .do(function (id) {
                        console.log(id);
                        if (id) {
                        }
                        else if (id === 0) {
                            //console.log("id is 0: adding a new article...");
                            _this.article = new article_1.Article(0, "New Article", null, null, null);
                        }
                        else {
                            //console.log("Invalid id: routing back to home...");
                            _this.router.navigate([""]);
                        }
                    })
                        .filter(function (id) { return id > 0; })
                        .switchMap(function (id) { return _this.articleService.get(id); })
                        .subscribe(function (article) {
                        _this.article = article;
                        _this.editArticleForm.patchValue({
                            title: _this.article.Title,
                            description: _this.article.Description,
                            text: "" //,
                        });
                        _this.setEntityRelationships(article.EntityRelationships);
                    });
                };
                ArticleDetailEditComponent.prototype.onInsert = function () {
                    var _this = this;
                    this.article = this.prepareSaveArticle();
                    this.articleService.add(this.article).subscribe(function (data) {
                        _this.article = data;
                        console.log("Article " + _this.article.Id + " has been added.");
                        _this.router.navigate([""]);
                    }, function (error) { return console.log(error); });
                    this.editArticleForm.reset();
                };
                ArticleDetailEditComponent.prototype.onUpdate = function () {
                    var _this = this;
                    var updatedArticle = this.prepareSaveArticle();
                    console.log(updatedArticle);
                    this.articleService.update(updatedArticle).subscribe(function (data) {
                        _this.article = data;
                        console.log("Article " + _this.article.Id + " has been updated.");
                        _this.router.navigate(["article/view", _this.article.Id]);
                    }, function (error) { return console.log(error); });
                    this.editArticleForm.reset();
                };
                ArticleDetailEditComponent.prototype.onDelete = function (article) {
                    var _this = this;
                    this.article = this.prepareSaveArticle();
                    var id = this.article.Id;
                    this.articleService.delete(id).subscribe(function (data) {
                        console.log("Article " + id + " has been deleted.");
                        _this.router.navigate([""]);
                    }, function (error) { return console.log(error); });
                };
                ArticleDetailEditComponent.prototype.onBack = function () {
                    this.router.navigate([""]);
                };
                ArticleDetailEditComponent.prototype.onArticleDetailView = function (article) {
                    this.router.navigate(["article/view", article.Id]);
                };
                ArticleDetailEditComponent.prototype.initEntityRelationship = function () {
                    return this.formBuilder.group({
                        Entity2Id: 0,
                        Entity2Name: "test",
                        Relationship: new forms_1.FormControl()
                    });
                };
                ArticleDetailEditComponent.prototype.setEntityRelationships = function (entityRelationships) {
                    var _this = this;
                    var entityRelationshipFGs = entityRelationships.map(function (entityRelationship) { return _this.formBuilder.group(entityRelationship); });
                    var entityRelationshipFormArray = this.formBuilder.array(entityRelationshipFGs);
                    this.editEntityRelationshipsForm.setControl('entityRelationships', entityRelationshipFormArray);
                };
                //get secretLairs(): FormArray {
                //    return this.heroForm.get('secretLairs') as FormArray;
                //};
                ArticleDetailEditComponent.prototype.addEntityRelationship = function () {
                    // add EntityRelationship to the list
                    var control = this.editEntityRelationshipsForm.controls['entityRelationships'];
                    control.push(this.initEntityRelationship());
                };
                ArticleDetailEditComponent.prototype.removeEntityRelationship = function (i) {
                    // remove EntityRelationship from the list
                    var control = this.editEntityRelationshipsForm.controls['entityRelationships'];
                    control.removeAt(i);
                };
                Object.defineProperty(ArticleDetailEditComponent.prototype, "entityRelationships", {
                    get: function () {
                        console.log("get entityRelationships");
                        return this.editArticleForm.get('entityRelationships');
                    },
                    enumerable: true,
                    configurable: true
                });
                ;
                ArticleDetailEditComponent.prototype.prepareSaveArticle = function () {
                    var formModel = this.editArticleForm.value;
                    var erFormModel = this.editEntityRelationshipsForm.value;
                    console.log("get entityRelationships");
                    console.log(erFormModel.entityRelationships);
                    var entityRelationshipsDeepCopy = erFormModel.entityRelationships.map(function (entityRelationship) { return Object.assign({}, entityRelationship); });
                    var saveArticle = {
                        Id: this.article.Id,
                        Title: formModel.title,
                        Description: formModel.description,
                        Text: formModel.text,
                        EntityRelationships: entityRelationshipsDeepCopy
                    };
                    return saveArticle;
                };
                return ArticleDetailEditComponent;
            }());
            ArticleDetailEditComponent = __decorate([
                core_1.Component({
                    selector: "article-detail-edit",
                    template: "\n<div *ngIf=\"article\">\n    <h2>\n        <a href=\"javascript:void(0)\" (click)=\"onBack()\">\n            &laquo; Back to Home\n        </a>\n    </h2>\n    <div class=\"article-container\">\n        <ul class=\"nav nav-tabs\">\n            <li role=\"presentation\" class=\"active\">\n                <a href=\"javascript:void(0)\">Edit</a>\n            </li>\n            <li role=\"presentation\" *ngIf=\"article.Id != 0\">\n                <a href=\"javascript:void(0)\" (click)=\"onArticleDetailView(article)\">View</a>\n            </li>\n        </ul>\n        <div class=\"panel panel-default\">\n            <div class=\"panel-body\">\n                <form class=\"article-detail-edit\" novalidate [formGroup]=\"editArticleForm\">\n                    <h3>\n                        {{ editArticleForm.get('title').value }}\n                        <span class=\"empty-field\" [hidden]=\"editArticleForm.get('title').valid\">\n                            Empty Title\n                        </span>\n                    </h3>\n                    <div class=\"form-group has-feedback\" [ngClass]=\"{'has-success': editArticleForm.get('title').valid, 'has-error': !editArticleForm.get('title').valid}\">\n                        <label for=\"input-title\">Title</label>\n                        <input id=\"input-title\" name=\"input-title\" type=\"text\" class=\"form-control\" formControlName=\"title\" placeholder=\"Insert the title...\"   />\n                        <span class=\"glyphicon form-control-feedback\" aria-hidden=\"true\" [ngClass]=\"{'glyphicon-ok': editArticleForm.get('title').valid, 'glyphicon-remove': !editArticleForm.get('title').valid}\"></span>\n                        <div [hidden]=\"editArticleForm.get('title').valid\" class=\"alert alert-danger\">\n                            You need to enter a valid Title.\n                        </div>\n                    </div>\n                    <div class=\"form-group\">\n                        <label for=\"input-description\">Description</label>\n                        <textarea id=\"input-description\" name=\"input-description\" class=\"form-control\" formControlName=\"description\" placeholder=\"Insert a suitable description...\" ></textarea>\n                    </div>\n                    <div class=\"form-group\">\n                        <label for=\"input-text\">Text</label>\n                        <textarea id=\"input-text\" name=\"input-text\" class=\"form-control\" formControlName=\"description\" placeholder=\"Insert a suitable description...\"></textarea>\n                    </div>\n\n                    <div *ngIf=\"article.Id == 0\" class=\"commands insert\">\n                        <input type=\"button\" class=\"btn btn-primary\" value=\"Save\" (click)=\"onInsert()\" />\n                        <input type=\"button\" class=\"btn btn-default\" value=\"Cancel\" (click)=\"onBack()\" />\n                    </div>\n                    <div *ngIf=\"article.Id != 0\" class=\"commands update\">\n                        <input type=\"button\" class=\"btn btn-primary\" value=\"Update\" (click)=\"onUpdate()\" />\n                        <input type=\"button\" class=\"btn btn-danger\" value=\"Delete\" (click)=\"onDelete(article)\" />\n                        <input type=\"button\" class=\"btn btn-default\" value=\"Cancel\" (click)=\"onArticleDetailView(article)\" />\n                    </div>\n                    \n\n                    \n                </form>\n                <form class=\"article-detail-edit\" novalidate [formGroup]=\"editEntityRelationshipsForm\">\n                    <!--entityRelationships-->\n                    <div formArrayName=\"entityRelationships\">\n                      <div *ngFor=\"let entityRelationship of editEntityRelationshipsForm.controls.entityRelationships.controls; let i=index\" class=\"panel panel-default\">\n                        <div class=\"panel-heading\">\n                          <span>Relationship {{i + 1}}</span>\n                          <span class=\"glyphicon glyphicon-remove pull-right\" *ngIf=\"editEntityRelationshipsForm.controls.entityRelationships.controls.length > 1\" (click)=\"removeEntityRelationship(i)\"></span>\n                        </div>\n                        <div class=\"panel-body\" [formGroupName]=\"i\">\n                          <entity-relationship-edit [group]=\"editEntityRelationshipsForm.controls.entityRelationships.controls[i]\" [entityRelationship]=\"entityRelationship.value\" [relationships]=\"relationships\" [entities]=\"entities\"></entity-relationship-edit>\n                        </div>\n                      </div>\n                    </div>\n\n                    <div class=\"margin-20\">\n                      <a (click)=\"addEntityRelationship()\" style=\"cursor: default\">\n                        Add another relationship +\n                      </a>\n                    </div>\n                </form>\n            </div>\n        </div>\n    </div>\n</div>\n    ",
                    styles: []
                }),
                __metadata("design:paramtypes", [auth_service_1.AuthService,
                    article_service_1.ArticleService,
                    entity_service_1.EntityService,
                    relationship_service_1.RelationshipService,
                    router_1.Router,
                    router_1.ActivatedRoute,
                    forms_1.FormBuilder])
            ], ArticleDetailEditComponent);
            exports_1("ArticleDetailEditComponent", ArticleDetailEditComponent);
        }
    };
});
