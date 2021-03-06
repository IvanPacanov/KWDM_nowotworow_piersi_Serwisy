function [Y] = SegmentationImage2(PreProcessedImage)
f = waitbar(0,'Proszę czekać...');
pause(.5)  
Y=double(PreProcessedImage);

        k=2; % k: number of regions

        g=2; % g: number of GMM components

        beta=1; % beta: unitary vs. pairwise

        EM_iter=10; % max num of iterations

        MAP_iter=10; % max num of iterations
waitbar(.33,f,'Segmentacja zmian nowotworowych');
pause(1)
       % fprintf('Performing k-means segmentation\n');

        [X,GMM,ShapeTexture]=image_kmeans(Y,k,g);
        waitbar(.53,f,'Segmentacja zmian nowotworowych');
pause(1)
        [X,Y,GMM]=HMRF_EM(X,Y,GMM,k,g,EM_iter,MAP_iter,beta);

        Y=Y*80;
waitbar(.73,f,'Segmentacja zmian nowotworowych');
pause(1)
        Y=uint8(Y);
        
                Y=im2gray(Y);
    Y=double(Y);
    
    statsa = glcm(Y,0,ShapeTexture);
    ExtractedFeatures1=statsa;

Y=uint8(Y);
waitbar(1,f,'Koniec');
pause(1)

close(f)
end

