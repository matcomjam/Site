import { Injectable } from '@angular/core';
import { Router, NavigationExtras } from "@angular/router";
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { Subject } from 'rxjs/Subject';
import { URLSearchParams } from '@angular/http';

import 'rxjs/add/observable/forkJoin';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
import { Blog } from "../models/blog.model";
import { ListResult } from '../models/list-result';

@Injectable()
export class BlogService {

    blogList: Blog[];

    private _getUrl = '/api/Blog/Index';
    public _saveUrl: string = 'api/Blog/Save';
    public _updateUrl: string = 'api/Blog/Update/';
    public _deleteByIdUrl: string = 'api/Blog/Delete/';

    constructor(private http: HttpClient) { }

    getBlogs<T>(filter, offset: number, limit: number) {
        var query = this.toQueryString(filter);
        query = query != null && query !== "" ? query + '&' : "";
        return this.http.get(this._getUrl + "2/" + `?${query}offset=${offset}&limit=${limit}`);
    }

    toQueryString(obj) {
        var parts = [];
        for (var property in obj) {
            console.log('property', property)
            var value = obj[property];
            if (value != null && value != undefined)
                parts.push(encodeURIComponent(property) + '=' + encodeURIComponent(value));
        }

        return parts.join('&');
    }

    getBlogCount<T>(filter) {
        var query = this.toQueryString(filter)
        query = (query != null && query !== "") ? '?' + query : "";
        return this.http.get(this._getUrl + `${query}`);
    }

    getBlogById<T>(id: number) {
        var getByIdUrl = this._getUrl + '/' + id;
        return this.http.get(getByIdUrl);
    }

    saveBlog<T>(blog: Blog) {
        return this.http.post(this._saveUrl, blog)
    }

    deleteBlog<T>(id: number) {
        var deleteByIdUrl = this._deleteByIdUrl + id;
        return this.http.delete(deleteByIdUrl);
    }

    updateBlog<T>(blog: Blog) {
        return this.http.put(this._updateUrl, blog);
    }
}
