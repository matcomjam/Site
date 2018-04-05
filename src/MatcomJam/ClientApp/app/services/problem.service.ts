import { Injectable } from '@angular/core';
import { Router, NavigationExtras } from "@angular/router";
import { HttpClient, HttpHeaders, } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { Subject } from 'rxjs/Subject';
import 'rxjs/add/observable/forkJoin';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
import { Problem } from '../models/problem.model';


@Injectable()
export class ProblemService {

    private _getUrl = '/api/Problem/Index';
    public _saveUrl: string = 'api/Problem/Save';
    public _updateUrl: string = 'api/Problem/Update/';
    public _deleteByIdUrl: string = 'api/Problem/Delete/';

    selectedProblem: Problem = new Problem();
    constructor(private http: HttpClient) { }

    getProblems<T>(offset: number, limit: number, filter) {
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

    getProblemCount<T>(filter) {
        var query = this.toQueryString(filter)
        query = (query != null && query !== "") ? '?' + query : "";
        return this.http.get(this._getUrl + `${query}`);
    }

    getProblemById<T>(id: number) {
        var getByidUrl = this._getUrl + "/" + id;
        return this.http.get(getByidUrl)
    }

    saveProblem<T>(problem: Problem) {
        return this.http.post(this._saveUrl, problem)
            .map((res: Response) => res.json);
    }

    deleteProblem<T>(id: number) {
        var deleteByIdUrl = this._deleteByIdUrl + id;
        return this.http.delete(deleteByIdUrl)
    }

    updateProblem(problem: Problem) {
        return this.http.put(this._updateUrl, problem)
    }
}
