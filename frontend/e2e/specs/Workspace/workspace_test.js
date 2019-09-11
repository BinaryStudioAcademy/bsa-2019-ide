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
        Help.openFirstProject();

    });
 
    afterEach(() => {
        browser.reloadSession();
    });


    xit('should edit file', () => {

        workspace.openFirstfile();
        workspace.editOpenedFile(credentials.changedCode);
        browser.pause(5000);
        workspace.saveChanges();
        browser.refresh();
        validate.verifyEditedFile(credentials.expectedCodeChanges);

    });

    xit('should open project history', () => {

        workspace.openProjectDetails();
        workspace.openProjectHistory();
        workspace.openFirstFileHIstory();
        validate.verifyProjectHistory(credentials.expectedHistory);


        //add deleting 'aaa' from code
    });

    xit('should build project', () => {

        workspace.buildProject();
        wait.forNotificationToDisappear();
        workspace.openProjectDetails();
        workspace.openBuildResults();
        //something must happened

    });


    });