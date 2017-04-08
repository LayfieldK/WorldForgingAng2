import {Component, OnInit} from "@angular/core";
import { Router, ActivatedRoute, Params} from "@angular/router";
import {Article} from "./article";
import {AuthService} from "./auth.service";
import { ArticleService } from "./article.service";
import { FormBuilder, FormGroup, FormControl, Validators, FormArray } from '@angular/forms';
import { EntityRelationshipEditComponent } from "./entity-relationship-edit.component";
import { EntityRelationship } from "./entity-relationship";

@Component({
    selector: "article-detail-edit",
    template: `
<div *ngIf="article">
    <h2>
        <a href="javascript:void(0)" (click)="onBack()">
            &laquo; Back to Home
        </a>
    </h2>
    <div class="article-container">
        <ul class="nav nav-tabs">
            <li role="presentation" class="active">
                <a href="javascript:void(0)">Edit</a>
            </li>
            <li role="presentation" *ngIf="article.Id != 0">
                <a href="javascript:void(0)" (click)="onArticleDetailView(article)">View</a>
            </li>
        </ul>
        <div class="panel panel-default">
            <div class="panel-body">
                <form class="article-detail-edit" novalidate [formGroup]="editArticleForm">
                    <h3>
                        {{ editArticleForm.get('title').value }}
                        <span class="empty-field" [hidden]="editArticleForm.get('title').valid">
                            Empty Title
                        </span>
                    </h3>
                    <div class="form-group has-feedback" [ngClass]="{'has-success': editArticleForm.get('title').valid, 'has-error': !editArticleForm.get('title').valid}">
                        <label for="input-title">Title</label>
                        <input id="input-title" name="input-title" type="text" class="form-control" formControlName="title" placeholder="Insert the title..."   />
                        <span class="glyphicon form-control-feedback" aria-hidden="true" [ngClass]="{'glyphicon-ok': editArticleForm.get('title').valid, 'glyphicon-remove': !editArticleForm.get('title').valid}"></span>
                        <div [hidden]="editArticleForm.get('title').valid" class="alert alert-danger">
                            You need to enter a valid Title.
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="input-description">Description</label>
                        <textarea id="input-description" name="input-description" class="form-control" formControlName="description" placeholder="Insert a suitable description..." ></textarea>
                    </div>
                    <div class="form-group">
                        <label for="input-text">Text</label>
                        <textarea id="input-text" name="input-text" class="form-control" formControlName="description" placeholder="Insert a suitable description..."></textarea>
                    </div>
                    <!--entityRelationships-->
                    <div formArrayName="entityRelationships">
                      <div *ngFor="let entityRelationship of editArticleForm.controls.entityRelationships.controls; let i=index" class="panel panel-default">
                        <div class="panel-heading">
                          <span>Relationship {{i + 1}}</span>
                          <span class="glyphicon glyphicon-remove pull-right" *ngIf="editArticleForm.controls.entityRelationships.controls.length > 1" (click)="removeEntityRelationship(i)"></span>
                        </div>
                        <div class="panel-body" [formGroupName]="i">
                          <entity-relationship-edit [group]="editArticleForm.controls.entityRelationships.controls[i]" [entityRelationship]="entityRelationship"></entity-relationship-edit>
                        </div>
                      </div>
                    </div>

                    <div class="margin-20">
                      <a (click)="addEntityRelationship()" style="cursor: default">
                        Add another relationship +
                      </a>
                    </div>

                    <div *ngIf="article.Id == 0" class="commands insert">
                        <input type="button" class="btn btn-primary" value="Save" (click)="onInsert()" />
                        <input type="button" class="btn btn-default" value="Cancel" (click)="onBack()" />
                    </div>
                    <div *ngIf="article.Id != 0" class="commands update">
                        <input type="button" class="btn btn-primary" value="Update" (click)="onUpdate()" />
                        <input type="button" class="btn btn-danger" value="Delete" (click)="onDelete(article)" />
                        <input type="button" class="btn btn-default" value="Cancel" (click)="onArticleDetailView(article)" />
                    </div>
                </form>
            </div>
        </div>
    </div>
</div>
    `,
    styles: []
})

export class ArticleDetailEditComponent {
    article: Article;

    editArticleForm: FormGroup;
    

    constructor(
        private authService: AuthService,
        private articleService: ArticleService,
        private router: Router,
        private activatedRoute: ActivatedRoute,
        private formBuilder: FormBuilder) { }

    ngOnInit() {
        console.log('article detail edit init');
        this.editArticleForm = this.formBuilder.group({
            title: ['', Validators.required],
            description: ['', Validators.required],
            text: ['', Validators.required],
            entityRelationships: this.formBuilder.array([this.initEntityRelationship()])
        });

        if (!this.authService.isLoggedIn()) {
            this.router.navigate([""]);
        }
        var id;
        this.activatedRoute.params
            .map(params => +params['id'])
            .do(id => {
                console.log(id);
                if (id) {
                    console.log(id);
                } else if (id === 0) {
                    console.log("id is 0: adding a new article...");
                    this.article = new Article(0, "New Article", null, null, null);
                } else {
                    console.log("Invalid id: routing back to home...");
                    this.router.navigate([""]);
                }
            })
            .filter(id => id > 0)
            .switchMap(id => this.articleService.get(id))
            .subscribe(article => {
                this.article = article;
                this.editArticleForm.patchValue({
                    title: this.article.Title,
                    description: this.article.Description,
                    text: ""//,
                    ////entityRelationships: this.article.EntityRelationships
                    //entityRelationships: this.editArticleForm.value.entityRelationships
                });
                this.setEntityRelationships(article.EntityRelationships);
            })
            ;
    }

    onInsert() {
        this.article = this.prepareSaveArticle();
        this.articleService.add(this.article).subscribe(
            (data) => {
                this.article = data;
                console.log("Article " + this.article.Id + " has been added.");
                this.router.navigate([""]);
            },
            (error) => console.log(error)
        );
        this.editArticleForm.reset();
    }

    onUpdate() {
        let updatedArticle = this.prepareSaveArticle();
        console.log(updatedArticle);
        this.articleService.update(updatedArticle).subscribe(
            (data) => {
                this.article = data;
                console.log("Article " + this.article.Id + " has been updated.");
                this.router.navigate(["article/view", this.article.Id]);
            },
            (error) => console.log(error)
        );
        this.editArticleForm.reset();
    }

    onDelete(article : Article) {
        this.article = this.prepareSaveArticle();
        var id = this.article.Id;
        this.articleService.delete(id).subscribe(
            (data) => {
                console.log("Article " + id + " has been deleted.");
                this.router.navigate([""]);
            },
            (error) => console.log(error)
        );
    }

    onBack() {
        this.router.navigate([""]);
    }

    onArticleDetailView(article: Article) {
        this.router.navigate(["article/view", article.Id]);
    }

    initEntityRelationship() {
        return this.formBuilder.group({
            Entity1Name: "test"
            //street: ['street address', Validators.required]
            //postcode: ['']
        });
    }

    setEntityRelationships(entityRelationships: EntityRelationship[]) {
        const entityRelationshipFGs = entityRelationships.map(entityRelationship => this.formBuilder.group(entityRelationship));
        const entityRelationshipFormArray = this.formBuilder.array(entityRelationshipFGs);
        this.editArticleForm.setControl('entityRelationships', entityRelationshipFormArray);
    }

    //get secretLairs(): FormArray {
    //    return this.heroForm.get('secretLairs') as FormArray;
    //};

    addEntityRelationship() {
        // add EntityRelationship to the list
        const control = <FormArray>this.editArticleForm.controls['entityRelationships'];
        control.push(this.initEntityRelationship());
    }

    removeEntityRelationship(i: number) {
        // remove EntityRelationship from the list
        const control = <FormArray>this.editArticleForm.controls['entityRelationships'];
        control.removeAt(i);
    }

    prepareSaveArticle(): Article {
        const formModel = this.editArticleForm.value;
        const saveArticle: Article = {
            Id: this.article.Id,
            Title: formModel.title,
            Description: formModel.description,
            Text: formModel.text,
            EntityRelationships: null
        };
        return saveArticle;
    }
}
