import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class CodeService {

    constructor(private http: HttpClient) { }

    upload(problemId, code) {
        var formData = new FormData();
        formData.append('sourceFile', code);
        return this.http.post(`/api/problems/${problemId}/code`, formData);
    }
}
