import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Comment } from '../models/comment.model';

@Injectable()
export class CommentService {

    private _getUrl = '/api/Comment/Index';
    public _saveUrl: string = 'api/Comment/Save';
    public _updateUrl: string = 'api/Comment/Update/';
    public _deleteByIdUrl: string = 'api/Comment/Delete/';

    constructor(private http: HttpClient) { }

    getComment<T>() {
        return this.http.get(this._getUrl);
    }

    getBlogById<T>(id: number) {
        var getByIdUrl = this._getUrl + '/' + id;
        return this.http.get(getByIdUrl);
    }

    save<T>(comment: Comment) {
        return this.http.post(this._saveUrl, comment);
    }

    delete<T>(id: number) {
        var deleteByIdUrl = this._deleteByIdUrl + id;
        return this.http.delete(deleteByIdUrl);
    }

    updateBlog<T>(comment: Comment) {
        return this.http.put(this._updateUrl, comment);
    }
}
