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

    //postProblem<T>(problem: Problem) {
    //    //let body = JSON.stringify(problem);
    //    //console.log('service', body);
    //    return this.http.post(this._saveUrl, problem)
    //        //.map((x: Response) => {
    //        //    //console.log('response service', x);
    //        //    x.json();
    //        //});
    //}
    getProblems<T>() {
        return this.http.get(this._getUrl);
        //.map((data: Response) => {
        //    return <any>data.json();
        //});
        //console.log(this.problemList);
    }

    getProblemById<T>(id: number) {
        var getByidUrl = this._getUrl + "/" + id;
        return this.http.get(getByidUrl)
            //.map((res: Response) => res.json());
    }

    saveProblem<T>(problem: Problem)/*: Observable<string>*/ {
        //let body = JSON.stringify(problem);

        return this.http.post(this._saveUrl, problem)
            .map((res: Response) => res.json);
    }

    deleteProblem<T>(id: number) {
        var deleteByIdUrl = this._deleteByIdUrl + id;
        return this.http.delete(deleteByIdUrl)
            //.map((res: Response) => res.json());
    }

    updateProblem(problem: Problem) {
        //let body = JSON.stringify(problem);
        return this.http.put(this._updateUrl, problem)
            //.map((res: Response) => res.json());
    }
}
