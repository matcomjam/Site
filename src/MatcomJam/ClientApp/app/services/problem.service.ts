import { Injectable } from '@angular/core';
import { Router, NavigationExtras } from "@angular/router";
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { Subject } from 'rxjs/Subject';
import 'rxjs/add/observable/forkJoin';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
import { Problem } from '../models/problem.model';


@Injectable()
export class ProblemService {

    problemList: Problem[];
    constructor(private http: HttpClient) { }

    //protected getRequestHeaders(): { headers: HttpHeaders | { [header: string]: string | string[]; } } {
    //    let headers = new HttpHeaders({
    //    });

    //    return { headers: headers };
    //}

    getProblems<T>() {
        return this.http.get('/api/problem');
        //.map((data: Response) => {
        //    return <any>data.json();
        //});
        //console.log(this.problemList);
    }
}
