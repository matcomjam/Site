import { Injectable } from '@angular/core';
import { Router, NavigationExtras } from "@angular/router";
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { Subject } from 'rxjs/Subject';
import 'rxjs/add/observable/forkJoin';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
import { Blog } from "../models/blog.model";

@Injectable()
export class BlogService {

    private _getUrl = '/api/Blog/Index';
    public _saveUrl: string = 'api/Blog/Save';
    public _updateUrl: string = 'api/Blog/Update/';
    public _deleteByIdUrl: string = 'api/Blog/Delete/';

    constructor(private http: HttpClient) { }

    getBlogs<T>() {
        return this.http.get(this._getUrl);
    }

    getProblemById<T>(id: number) {
        var getByIdUrl = this._getUrl + '/' + id;
        return this.http.get(getByIdUrl);
    }

    saveBlog<T>(blog: Blog) {
        return this.http.post(this._saveUrl, blog)
            //.map((res: Response) => res.json());
    }

    deleteBlog<T>(id: number) {
        var deleteByIdUrl = this._deleteByIdUrl + id;
        return this.http.delete(deleteByIdUrl);
    }

    updateBlog<T>(blog: Blog) {
        return this.http.put(this._updateUrl, blog);
    }
}
