
import { Component, OnInit } from '@angular/core';
import { fadeInOut } from '../../services/animations';
import { BlogService } from '../../services/blog.service';
import { Blog } from '../../models/blog.model';
import { AuthService } from '../../services/auth.service';
import { AccountService } from '../../services/account.service';
import { User } from '../../models/user.model';

@Component({
    selector: 'blog',
    templateUrl: './blog.component.html',
    styleUrls: ['./blog.component.css'],
    animations: [fadeInOut],
    providers: [BlogService]
})
export class BlogComponent implements OnInit {
    isUserLoggedIn: boolean;
    blogList: Blog[];

    offset: number = 0;
    limit: number = 4;
    size: number;

    autor: String;

    filter: any = {};

    constructor(private blogService: BlogService, private authService: AuthService, private accountService: AccountService) { }

    ngOnInit(): void {
        this.isUserLoggedIn = this.authService.isLoggedIn;
        this.loadData();
    }

    loadData() {
        this.getSize();
        this.findAll();
    }

    delete(id) {
        var ans = confirm("Do you want to delete blog with Id: " + id);
        if (ans) {
            this.blogService.deleteBlog(id)
                .subscribe(p => {
                    this.loadData();
                });
        }
    }

    getSize() {
        this.blogService.getBlogCount(this.filter)
            .subscribe(c => {
                this.size = Number(c)
                console.log('size', this.size);
            });
    }

    findAll(offset: number = 1) {
        this.blogService.getBlogs(this.filter, offset, this.limit)
            .subscribe(b => {
                this.blogList = <Blog[]>(b);
                console.log('blogs', this.blogList);
            });
    }

    onPageChange(offset) {
        this.offset = offset;
        this.findAll((offset / this.limit) + 1);
    }

    getUserName(id) {
        //return this.authService.currentUser ? this.authService.currentUser.userName : "";
        return this.accountService.getUser(id)
            .subscribe(res => this.autor = res.userName);
    }

    onSearchChanged() {
        this.loadData();
    }
}
