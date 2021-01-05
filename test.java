public int candy(int[] ratings) {
int[] leftNums = new int[ratings.length];
int[] rightNums = new int[ratings.length];
Arrays.fill(leftNums,1);
Arrays.fill(rightNums,1);
for(int i = 1 ; i < ratings.length ; i++ ){
    if(ratings[i] > ratings[i - 1 ]){
        leftNums[i] = leftNums[i-1]+1;
    }
}
for(int i = ratings.length -2 ; i >= 0 ; i--){
    if(ratings[i]>ratings[i+1]){
        rightNums[i] = rightNums[i+1] +1;
    }
}
int res = 0;
for(int i = 0; i < ratings.length ; i++){
    res += Math.max(leftNums[i],rightNums[i]);
}
return res;
}