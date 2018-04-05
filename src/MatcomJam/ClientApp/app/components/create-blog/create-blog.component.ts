import { Component, OnInit } from '@angular/core';
import { BlogService } from '../../services/blog.service';
import { Blog } from "../../models/blog.model";
import { User } from "../../models/user.model";
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { AuthService } from '../../services/auth.service';


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
    currentUser: User = new User();

    constructor(private _formB: FormBuilder, private blogService: BlogService,
        private _router: Router, private _avRoute: ActivatedRoute, private authService: AuthService) {
        if (this._avRoute.snapshot.params["id"]) {
            this.id = this._avRoute.snapshot.params["id"];
        }

        //this.currentUser = new User(this.authService.currentUser.id, this.authService.currentUser.userName);

        this.blogForm = this._formB.group({
            id: 0,
            title: ['', [Validators.required]],
            description: ['', [Validators.required]],
            userId: this.authService.currentUser.id,
            userName: this.authService.currentUser.userName
        });
    }

    ngOnInit() {
        if (this.id > 0) {
            this.title = "Edit";
            this.blogService.getBlogById(this.id)
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
                    console.log('blog details', this.blogForm.value);
                    this._router.navigate(['/blogs']);
                })
            //error => this.errorMessage = error);
        }
        else if (this.title == "Edit") {
            this.blogService.updateBlog(this.blogForm.value)
                .subscribe(p => {
                    this._router.navigate(['/blogs']);
                })
            //error => this.errorMessage = error);
        }
    }

    cancel() {
        this._router.navigate(['/blogs']);
    }
}
