import { Component, OnInit } from '@angular/core';
import { BlogService } from "../../services/blog.service";
import { CommentService } from "../../services/comment.service";
import { Blog } from "../../models/blog.model";
import { Router, ActivatedRoute } from '@angular/router';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { AuthService } from '../../services/auth.service';
import { Comment } from '../../models/comment.model';

@Component({
    selector: 'app-selected-blog',
    templateUrl: './selected-blog.component.html',
    styleUrls: ['./selected-blog.component.css']
})
export class SelectedBlogComponent implements OnInit {
    comments: Comment[];

    blogId: number;
    autorId: string;
    //autorName: string;

    blog: Blog;
    actualComment: any = {};

    constructor(private blogService: BlogService, private _router: Router,
        private _avRoute: ActivatedRoute,
        private commentService: CommentService,
        private _fromB: FormBuilder,
        private authService: AuthService) {
        if (this._avRoute.snapshot.params["id"]) {
            this.blogId = this._avRoute.snapshot.params["id"];
            this.autorId = this.authService.currentUser.id;
            //this.autorName = this.authService.currentUser.userName;
        }
    }

    ngOnInit() {
        this.blogService.getBlogById(this.blogId)
            .subscribe(b => {
                this.blog = <Blog>(b);
            });
        this.loadData();
    }

    loadData() {
        this.commentService.getComment(this.blogId)
            .subscribe(c => {
                this.comments = <Comment[]>(c);
            });
    }

    saveComment() {
        this.actualComment.userId = this.autorId;
        this.actualComment.blogId = this.blogId;

        console.log('comment so far', this.actualComment)

        this.commentService.save(this.actualComment)
            .subscribe(res => {
                console.log('victoria')
                this.loadData();
                this.actualComment.description = "";
            });
    }
}
