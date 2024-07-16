import mitt from 'mitt'
import type { NamedEvents } from '@mtvproject/kernel-interface'
export const globalObservable = mitt<NamedEvents>()
