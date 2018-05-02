import { Component, OnInit, Input } from '@angular/core';
import { fadeInOut } from '../../services/animations';
import { ConfigurationService } from '../../services/configuration.service';
import { BlogService } from "../../services/blog.service";
import { Blog } from '../../models/blog.model';


@Component({
    selector: 'home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css'],
    animations: [fadeInOut],
    providers: [BlogService]
})
export class HomeComponent implements OnInit {
    blogList: Blog[];

    offset: number = 0;
    limit: number = 3;
    size: number;

    constructor(private blogService: BlogService) { }

    ngOnInit(): void {
        this.loadData();
    }

    loadData() {
        this.getSize();
        this.findAll(this.limit);
    }

    onPageChange(offset) {
        this.offset = offset;
        this.findAll(this.limit, (offset / this.limit) + 1);
    }

    getSize() {
        this.blogService.getBlogCount(null)
            .subscribe(c => {
                this.size = Number(c)
              //  console.log('size', this.size);
            });
    }
    
    findAll(limit: number, offset: number = 1) {
        this.blogService.getBlogs(null, offset, limit)
            .subscribe(b => {
                this.blogList = <Blog[]>(b);
            });
    }
}
