function [data] = Login_QuestionHTTP(userName,password)
%LOGIN_QUESTIONHTTP Summary of this function goes here
%   Detailed explanation goes here
url = 'http://localhost:8000/api/v1/User';

USER.userName  = userName;
USER.password = password;

options = weboptions('RequestMethod', 'post');

data = webwrite(url, USER, options);
end

