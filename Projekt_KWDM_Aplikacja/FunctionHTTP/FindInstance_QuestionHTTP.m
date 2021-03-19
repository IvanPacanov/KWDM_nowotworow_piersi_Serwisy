function [Instances] = FindInstance_QuestionHTTP(DicomInfo)
%FINDINSTANCE_QUESTIONHTTP Summary of this function goes here
%   Detailed explanation goes here
url = 'http://localhost:5001/api/v1/Pacs/FindInstances';
options = weboptions('RequestMethod', 'post');
Instances = webwrite(url, DicomInfo, options);
end

