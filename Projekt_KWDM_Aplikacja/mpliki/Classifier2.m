function [ac] = Classifier2(file)
load ExtractedFeatures;

A=1:20;
B=21:40;
C=41:60;

P = [A B C];
Tc = [1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1  2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3];

k=2; % k: number of regions
g=2; % g: number of GMM components

beta=1; % beta: unitary vs. pairwise
EM_iter=10; % max num of iterations
MAP_iter=10; % max num of iterations

    file=im2gray(file);
    file=adaptivemedian(file);
    [Xk,GMMk,ShapeTexture]=image_kmeans(file,k,g);
    PreProcessedImage(:,:,1)=file;
    PreProcessedImage(:,:,2)=file;
    PreProcessedImage(:,:,3)=file;

    
    stats= gmmsegmentation(Xk,PreProcessedImage,GMMk,k,g,beta,EM_iter,MAP_iter,ShapeTexture);

    ShapeTexture=stats.ShapeTexture;
    
    for i=1:60
        
         statsa=ExtractedFeature{i};
         ShapeTexturea=statsa.ShapeTexture;
         
         
         diff1(i)=corr2(stats.autoc,statsa.autoc);
         diff2(i)=corr2(stats.contr,statsa.contr);
         diff3(i)=corr2(stats.corrm,statsa.corrm);
         diff4(i)=corr2(stats.cprom,statsa.cprom);
         diff5(i)=corr2(stats.cshad,statsa.cshad);
         diff6(i)=corr2(stats.dissi,statsa.dissi);
         diff7(i)=corr2(stats.energ,statsa.energ);
         diff8(i)=corr2(stats.entro,statsa.entro);
         diff9(i)=corr2(stats.homom,statsa.homom);
         diff10(i)=corr2(stats.homop,statsa.homop);
         diff11(i)=corr2(stats.maxpr,statsa.maxpr);
         diff12(i)=corr2(stats.sosvh,statsa.sosvh);
         diff13(i)=corr2(stats.savgh,statsa.savgh);
         diff14(i)=corr2(stats.svarh,statsa.svarh);
         diff15(i)=corr2(stats.senth,statsa.senth);
         diff16(i)=corr2(stats.dvarh,statsa.dvarh);
         diff17(i)=corr2(stats.denth,statsa.denth);
         diff18(i)=corr2(stats.inf1h,statsa.inf1h);
         diff19(i)=corr2(stats.inf2h,statsa.inf2h);
         diff19(i)=corr2(stats.indnc,statsa.indnc);
         diff19(i)=corr2(stats.idmnc,statsa.idmnc);
         diff20(i)=corr2(ShapeTexture,ShapeTexturea);
    

    end

    [val1 index1]=max(diff1);
    [val2 index2]=max(diff2);
    [val3 index3]=max(diff3);
    [val4 index4]=max(diff4);
    [val5 index5]=max(diff5);
    [val6 index6]=max(diff6);
    [val7 index7]=max(diff7);
    [val8 index8]=max(diff8);
    [val9 index9]=max(diff9);
    [val10 index10]=max(diff10);
    [val11 index11]=max(diff11);
    [val12 index12]=max(diff12);
    [val13 index13]=max(diff13);
    [val14 index14]=max(diff14);
    [val15 index15]=max(diff15);
    [val16 index16]=max(diff16);
    [val17 index17]=max(diff17);
    [val18 index18]=max(diff18);
    [val19 index19]=max(diff19);
    [val20 index20]=max(diff20);


T = ind2vec(Tc);

spread = 1;

net = newpnn(P,T,spread);

A = sim(net,P);
Ac = vec2ind(A);

pl(1) = index20;
p1(2) = index1;
p1(3) = index2;
p1(4) = index3;
p1(5) = index4;
p1(6) = index5;
p1(7) = index6;
p1(8) = index7;
p1(9) = index8;
p1(10) = index9;
p1(11) = index10;
p1(12) = index11;
p1(13) = index12;
p1(14) = index13;
p1(15) = index14;
p1(16) = index15;
p1(17)= index16;
p1(18) = index17;
p1(19) = index18;
p1(20) = index19;


% pl = index20;
a = sim(net,pl);
ac = vec2ind(a);

end

