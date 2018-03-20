// ======================================
// Author: Ebenezer Monney
// Email:  info@ebenmonney.com
// Copyright (c) 2017 www.ebenmonney.com
// 
// ==> Gun4Hire: contact@ebenmonney.com
// ======================================

import { Component, OnInit } from '@angular/core';
import { fadeInOut } from '../../services/animations';
import { ContestService } from '../../services/contest.service';
import {Contest} from '../../models/contest.model';

@Component({
    selector: 'contest',
    templateUrl: './contest.component.html',
    styleUrls: ['./contest.component.css'],
    animations: [fadeInOut],
    providers: [ContestService]
})

export class ContestComponent implements OnInit{

    contestList:Contest[];

    constructor(private contestService: ContestService) { }

    ngOnInit(): void {
        this.loadData();
    }

    loadData() {
        this.contestService.getContests()
            .subscribe(c => {
                this.contestList = <Contest[]>(c);
                console.log('contests', this.contestList);
            });
    }

    delete(id) {
        var ans = confirm("Do you want to delete problem with Id: " + id);
        if (ans) {
            this.contestService.deleContest(id)
                .subscribe(p => {
                    this.loadData();
                });
        }
    }
}
