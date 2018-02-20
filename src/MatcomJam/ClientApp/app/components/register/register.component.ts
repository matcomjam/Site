import { Component, OnInit, ViewChild, Input } from '@angular/core';

import { AlertService, MessageSeverity, DialogType } from '../../services/alert.service';
import { AuthService } from "../../services/auth.service";
import { ConfigurationService } from '../../services/configuration.service';
import { Utilities } from '../../services/utilities';
import {UserRegister} from '../../models/user-register.model';
import { AccountService } from "../../services/account.service";

import { UserEdit } from '../../models/user-edit.model';

import { User } from '../../models/user.model';

import { Role } from '../../models/role.model';
import { Permission } from '../../models/permission.model';



@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})

export class RegisterComponent implements OnInit {

    private isEditMode = false;
    private isNewUser = false;
    private isSaving = false;
    private isChangePassword = false;
    private isEditingSelf = false;
    private showValidationErrors = false;
    private editingUserName: string;
    private uniqueId: string = Utilities.uniqueId();
    private user: User = new User();
    private userEdit: UserEdit;
    private allRoles: Role[] = [];

    public formResetToggle = true;

//    public changesSavedCallback: () => void;
//    public changesFailedCallback: () => void;
//    public changesCancelledCallback: () => void;

    @Input()
    isGeneralEditor = false;

    userRegister = new UserRegister();

    @ViewChild('f')
    private form;

    //ViewChilds Required because ngIf hides template variables from global scope
    @ViewChild('userName')
    private userName;

    @ViewChild('userPassword')
    private userPassword;

    @ViewChild('email')
    private email;

    @ViewChild('currentPassword')
    private currentPassword;

    @ViewChild('newPassword')
    private newPassword;

    @ViewChild('confirmPassword')
    private confirmPassword;

//    constructor(private alertService: AlertService, private accountService: AccountService) {

//    }

    ngOnInit() {
    }

    register() {
        this.isSaving = true;
        //this.alertService.startLoadingMessage("", "AttemptinLogin...");

        //this.accountService.newUser(this.userEdit).subscribe(user => this.saveSuccessHelper(user), error => this.saveFailedHelper(error));

    }

//    private saveSuccessHelper(user?: User) {
//        this.testIsRoleUserCountChanged(this.user, this.userEdit);

//        if (user)
//            Object.assign(this.userEdit, user);

//        this.isSaving = false;
//        this.alertService.stopLoadingMessage();
//        this.isChangePassword = false;
//        this.showValidationErrors = false;

//        this.deletePasswordFromUser(this.userEdit);
//        Object.assign(this.user, this.userEdit);
//        this.userEdit = new UserEdit();
//        this.resetForm();


//        if (this.isGeneralEditor) {
//            if (this.isNewUser)
//                this.alertService.showMessage("Success", `User \"${this.user.userName}\" was created successfully`, MessageSeverity.success);
//            else if (!this.isEditingSelf)
//                this.alertService.showMessage("Success", `Changes to user \"${this.user.userName}\" was saved successfully`, MessageSeverity.success);
//        }

//        if (this.isEditingSelf) {
//            this.alertService.showMessage("Success", "Changes to your User Profile was saved successfully", MessageSeverity.success);
//            this.refreshLoggedInUser();
//        }

//        this.isEditMode = false;


//        if (this.changesSavedCallback)
//            this.changesSavedCallback();
//    }

//    private saveFailedHelper(error: any) {
//        this.isSaving = false;
//        this.alertService.stopLoadingMessage();
//        this.alertService.showStickyMessage("Save Error", "The below errors occured whilst saving your changes:", MessageSeverity.error, error);
//        this.alertService.showStickyMessage(error, null, MessageSeverity.error);

//        if (this.changesFailedCallback)
//            this.changesFailedCallback();
//    }

//    private testIsRoleUserCountChanged(currentUser: User, editedUser: User) {

//        let rolesAdded = this.isNewUser ? editedUser.roles : editedUser.roles.filter(role => currentUser.roles.indexOf(role) == -1);
//        let rolesRemoved = this.isNewUser ? [] : currentUser.roles.filter(role => editedUser.roles.indexOf(role) == -1);

//        let modifiedRoles = rolesAdded.concat(rolesRemoved);

//        if (modifiedRoles.length)
//            setTimeout(() => this.accountService.onRolesUserCountChanged(modifiedRoles));
//    }

//    public deletePasswordFromUser(user: UserEdit | User) {
//        let userEdit = <UserEdit>user;

//        delete userEdit.currentPassword;
//        delete userEdit.newPassword;
//        delete userEdit.confirmPassword;
//    }

//    resetForm(replace = false) {
//        this.isChangePassword = false;

//        if (!replace) {
//            this.form.reset();
//        }
//        else {
//            this.formResetToggle = false;

//            setTimeout(() => {
//                this.formResetToggle = true;
//            });
//        }
//    }

//    private refreshLoggedInUser() {
//        this.accountService.refreshLoggedInUser()
//            .subscribe(user => {
//                    this.loadCurrentUserData();
//                },
//                error => {
//                    this.alertService.resetStickyMessage();
//                    this.alertService.showStickyMessage("Refresh failed", "An error occured whilst refreshing logged in user information from the server", MessageSeverity.error, error);
//                });
//    }

//    private loadCurrentUserData() {
//        this.alertService.startLoadingMessage();

//        if (this.canViewAllRoles) {
//            this.accountService.getUserAndRoles().subscribe(results => this.onCurrentUserDataLoadSuccessful(results[0], results[1]), error => this.onCurrentUserDataLoadFailed(error));
//        }
//        else {
//            this.accountService.getUser().subscribe(user => this.onCurrentUserDataLoadSuccessful(user, user.roles.map(x => new Role(x))), error => this.onCurrentUserDataLoadFailed(error));
//        }
//    }

//    get canViewAllRoles() {
//        return this.accountService.userHasPermission(Permission.viewRolesPermission);
//    }

//    private onCurrentUserDataLoadSuccessful(user: User, roles: Role[]) {
//        this.alertService.stopLoadingMessage();
//        this.user = user;
//        this.allRoles = roles;
//    }

//    private onCurrentUserDataLoadFailed(error: any) {
//        this.alertService.stopLoadingMessage();
//        this.alertService.showStickyMessage("Load Error", `Unable to retrieve user data from the server.\r\nErrors: "${Utilities.getHttpResponseMessage(error)}"`,
//            MessageSeverity.error, error);

//        this.user = new User();
//    }
}
