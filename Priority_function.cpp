//============================================================================
// Name        : Priority_function.cpp
// Author      : Ahmed mohamed
// Version     : v 1.0
// Copyright   : Your copyright notice
// Description : Logic function of priority
//============================================================================

#include <iostream>
#define PREEMPTIVE 0

using namespace std;


typedef struct process{
	process * next = NULL;	// pionter to the next process in the queue
	process * prev = NULL;	// pionter to the previous process in the queue
	int priority;			// the priority of the process
	int start_time;			// the start time of the process
	int duration;			// time for the process to finish
	int num;				// number of the process

} process;

process * current = NULL; 	// ponter to the current process in the queue

process * head = NULL;		// ponter to the first process in the ready queue
process * tail = NULL;		// ponter to the last process in the ready queue

process * head_p = NULL;	// ponter to the first process in the processes queue
process * tail_p = NULL;	// ponter to the last  process in the processes queue


void insertProcessInsideReadyQueue(int priority, int start_time, int duration, int num)
{
	// create tmp process to insert it in the ready queue 
	process *link = (process*) malloc(sizeof(process));
	link->priority = priority;
	link->start_time = start_time;
	link->duration = duration;
	link->num = num;
	
	// If head is empty, create new queue
	if(head==NULL)
	{
		link->next = NULL;
		link->prev = NULL;
		tail = link;
		head = link;

	}
	// insert the procees in the queue in the right position according to the priority
	else if(link->priority > 5/2){
#if PREEMPTIVE
		current =  head;
#else
		current  = head->next;
#endif
		while(current->priority >= link->priority ){
			current = current->next;
		}
		link->next = current;
		link->prev = current->prev;
		current->prev = link;
		if(link->prev == NULL) head = link;
		else link->prev->next = link;

	}
	else{
		current =  tail;
		while(current->priority < link->priority ){
			current = current->prev;
		}
		link->prev = current;
		link->next = current->next;
		current->next = link;
		if(link->next == NULL) tail = link;
		else link->prev->next = link;
	}
	//cout<<"tail -> "<<tail->num<<endl; fflush(stdout);
}

void processqueue(int priority, int start_time, int duration, int num)
{
	// create tmp process to insert it in the queue
	process *link = (process*) malloc(sizeof(process));
	link->priority = priority;
	link->start_time = start_time;
	link->duration = duration;
	link->num = num;
	
	// If head is empty, create new queue
	if(head_p == NULL)
	{
		link->next = NULL;
		link->prev = NULL;
		tail_p = link;
		head_p = link;
	}
	// insert the procees in the queue in the right position according to the start time
	else{
		current =  tail_p;
		//cout<<"in "<<endl; fflush(stdout);
		//cout<<current->start_time <<" " << link->start_time<<endl; fflush(stdout);
		while(current->start_time > link->start_time ){
			current = current->prev;
		}
		//cout<<"out "<<endl; fflush(stdout);

		link->prev = current;
		link->next = current->next;
		current->next = link;
		if(link->next == NULL) tail_p = link;
		else link->next->prev = link;

	}
	//cout<<"head_p  -> "<<tail_p->num<<endl; fflush(stdout);

}




int main(){

	int P_num	// number of process entered by the user
	int	i;		// flag for the loops
	int d;		// detect the current timing of the process
	process *p = (process*) malloc(sizeof(process));
	cout<<"Enter number of process : ";			fflush(stdout);
	cin>>P_num;									fflush(stdin);
	
	for(i = 0; i < P_num; i++){
		p->num = i+1;

		cout<< "Enter start time of process "<<i<<": ";	fflush(stdout);
		//cin>>arr[i].start_time;						fflush(stdin);
		cin>>p->start_time;								fflush(stdin);
		
		cout<< "Enter duration of process "<<i<<": ";	fflush(stdout);
		//cin>>arr[i].duration;							fflush(stdin);
		cin>>p->duration;								fflush(stdin);
		
		cout<< "\nEnter priority of process "<<i<<": ";	fflush(stdout);
		//cin>>arr[i].priority;							fflush(stdin);
		cin>>p->priority;								fflush(stdin);
		
		processqueue(p->priority, p->start_time, p->duration, p->num);
	}
	cout<<"\nSequence : "; fflush(stdout);
	
	p = head_p;
	d = p->start_time;
	
	insertProcessInsideReadyQueue(p->priority, p->start_time, p->duration, p->num);
	
	p = p->next;
	while (head != NULL){
		if(p != NULL && p->start_time == d){
			insertProcessInsideReadyQueue(p->priority, p->start_time, p->duration, p->num);
			p = p->next;
		}
		else{
			cout<<head->num<<" "; fflush(stdout);
			head->duration--;
			d++;
			if(head->duration == 0) head = head->next;
		}
	}
	return 0;
}
