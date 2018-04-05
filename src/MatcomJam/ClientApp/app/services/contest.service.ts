import { Injectable } from '@angular/core';
import { Router, NavigationExtras } from "@angular/router";
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { Subject } from 'rxjs/Subject';
import 'rxjs/add/observable/forkJoin';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
import {Contest} from "../models/contest.model";

@Injectable()
export class ContestService {

    private _getUrl = '/api/Contest/Index';
    public _saveUrl: string = 'api/Contest/Save';
    public _updateUrl: string = 'api/Contest/Update/';
    public _deleteByIdUrl: string = 'api/Contest/Delete/';

    selectedContest: Contest = new Contest();

    constructor(private http: HttpClient) { }

    getContests<T>(filter, offset: number, limit: number) {
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

    getContestCount<T>(filter) {
        var query = this.toQueryString(filter)
        query = (query != null && query !== "") ? '?' + query : "";
        return this.http.get(this._getUrl + `${query}`);
    }

    getContestById<T>(id: number) {
        var getByidUrl = this._getUrl + "/" + id;
        return this.http.get(getByidUrl);
    }

    saveContest<T>(contest: Contest) {
        return this.http.post(this._saveUrl, contest)
            .map((res: Response) => res.json);
    }

    deleContest<T>(id: number) {
        var deleteByIdUrl = this._deleteByIdUrl + id;

        return this.http.delete(deleteByIdUrl)
    }

    updateContest<T>(contest: Contest) {
        return this.http.put(this._updateUrl, contest);
    }
}
