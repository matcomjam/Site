// ======================================
// Author: Ebenezer Monney
// Email:  info@ebenmonney.com
// Copyright (c) 2017 www.ebenmonney.com
// 
// ==> Gun4Hire: contact@ebenmonney.com
// ======================================

import { Component, OnInit } from '@angular/core';
import { fadeInOut } from '../../services/animations';
import { BlogService } from '../../services/blog.service';
import { Blog } from '../../models/blog.model';

@Component({
    selector: 'blog',
    templateUrl: './blog.component.html',
    styleUrls: ['./blog.component.css'],
    animations: [fadeInOut],
    providers: [BlogService]
})
export class BlogComponent implements OnInit {

    blogList: Blog[];

    offset: number = 0;
    limit: number = 4;
    size: number;

    constructor(private blogService: BlogService) { }

    ngOnInit(): void {
        this.loadData();
    }

    loadData() {
        this.getSize();
        this.findAll(this.limit);
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
        this.blogService.getBlogCount()
            .subscribe(c => {
                this.size = Number(c)
                console.log('size', this.size);
            });
    }

    findAll(limit: number, offset: number = 1) {
        this.blogService.getBlogs(offset, limit)
            .subscribe(b => {
                this.blogList = <Blog[]>(b);
            });
    }

    onPageChange(offset) {
        this.offset = offset;
        this.findAll(this.limit, (offset / this.limit) + 1);
    }
}
