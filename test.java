class Solution {
    public int calPoints(String[] ops) {
        Stack<Integer> stack = new Stack<>();
        for(int i = 0 ; i < ops.length ; i++){
            String temp = ops[i];
            if(temp.equals("C")){
                stack.pop();
            }else if(temp.equals("D")){
                stack.push(stack.peek()*2);
            }else if(temp.equals("+")){
                Integer x1 = stack.pop();
                Integer x2 = stack.peek();
                stack.push(x1);
                stack.push(x1+x2);
            }else{
                stack.push(Integer.valueOf(temp));
            }
        }
        int sum = 0;
        while(!stack.isEmpty()){
            sum += stack.pop();
        }
        return sum;
    }
}