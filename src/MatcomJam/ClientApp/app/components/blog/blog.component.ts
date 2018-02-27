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
    animations: [fadeInOut]
})
export class BlogComponent implements OnInit {

    blogList: Blog[];
    constructor(private blogService: BlogService) { }

    ngOnInit(): void {
        this.blogService.getBlogs()
            .subscribe(b => {
                this.blogList = <Blog[]>(b);
                console.log('blogs', this.blogList);
            });

    }
}
