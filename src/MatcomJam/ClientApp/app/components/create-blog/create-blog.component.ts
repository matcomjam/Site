import { Component, OnInit } from '@angular/core';
import { BlogService } from '../../services/blog.service';
import { Blog } from "../../models/blog.model";
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
    selector: 'app-create-blog',
    templateUrl: './create-blog.component.html',
    styleUrls: ['./create-blog.component.css'],
    providers: [BlogService]
})
export class CreateBlogComponent implements OnInit {
    blogForm: FormGroup;
    title: string = "Create";
    id: number;
    errorMessage: any;
    b:Blog;
    constructor(private _formB: FormBuilder, private blogService: BlogService,
        private _router: Router, private _avRoute: ActivatedRoute) {
        if (this._avRoute.snapshot.params["id"]) {
            this.id = this._avRoute.snapshot.params["id"];
        }

        this.blogForm = this._formB.group({
            id: 0,
            title: ['', [Validators.required]],
            description: ['', [Validators.required]],
            userId: 0
        });
    }

    ngOnInit() {
        if (this.id > 0) {
            this.title = "Edit";
            this.blogService.getProblemById(this.id)
                .subscribe((p: Blog) => {
                    this.blogForm.setValue(p);
                });
            //error => this.errorMessage = error;
        }
    }

    save() {
        if (!this.blogForm.valid) {
            return;
        }
        if (this.title == "Create") {
            this.blogService.saveBlog(this.blogForm.value)
                .subscribe(p => {
                    this._router.navigate(['/blogs']);
                })
            //error => this.errorMessage = error);
        }
        else if (this.title == "Edit") {
            this.blogService.updateBlog(this.blogForm.value)
                .subscribe(p => {
                    console.log('por que no estas yendo pa esa direccion');
                    this._router.navigate(['/blogs']);
                })
            //error => this.errorMessage = error);
        }
    }

    cancel() {
        this._router.navigate(['/blogs']);
    }
}
