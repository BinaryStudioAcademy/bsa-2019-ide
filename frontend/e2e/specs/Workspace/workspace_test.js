const WorkspaceActions = require('./actions/workspace_pa');
const workspace = new WorkspaceActions();

const Help = require('../../helpers/helpers');
const Assert = require('../../helpers/validators');
const Wait = require('../../helpers/waiters');
const validate = new Assert();
const wait = new Wait();

const credentials = require('./../testData.json');



describe('Online-IDE workspace', () => {

    beforeEach(() => {
       
        browser.url(credentials.appUrl);
        Help.loginWithDefaultUser();
        wait.forSpinner();
        Help.openMyFirstProject();

    });
 
    afterEach(() => {
        browser.reloadSession();
    });


    it('should edit file', () => {

        workspace.openFirstfile();
        workspace.editOpenedFile(credentials.changedCode);
        workspace.saveChanges();
        browser.refresh();
        validate.verifyEditedFile(credentials.expectedCodeChanges);
        workspace.deleteChanges();
        workspace.saveChanges();
    });

    it('should open project history', () => {

        workspace.openProjectDetails();
        workspace.openProjectHistory();
        workspace.openFirstFileHIstory();
        validate.verifyProjectHistory();

    });

    it('should build project', () => {

        wait.forNotificationToDisappear();
        workspace.buildProject();
        validate.notificationTextIs(credentials.buildNotification)
        wait.forNotificationToDisappear();
        workspace.openProjectDetails();
        workspace.openBuildResults();
        //something must happened (still nothing)

    });

    it('should not edit by second user in parallel editing', () => {

        workspace.openFirstfile();
        workspace.editOpenedFile(credentials.changedCode);
        Help.secondWindowLogin();
        Help.openAssignedFirstProject();
        workspace.openFirstfile();
        workspace.editBigComment(credentials.changedCode);
        validate.verifyEditorMessage(credentials.editorMessage);

    });


    });